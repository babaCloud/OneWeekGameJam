using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace sakuGame
{
    namespace BGM
    {

        public class GuzaiGenerator : MonoBehaviour, IWhen_SlowTiming
        {
            #region jsonのnumを読み込みたい
            [Serializable]
            public class InputJson
            {
                public Notes[] notes;
                public int BPM;
            }

            [Serializable]
            public class Notes
            {
                public int num;
                public int block;
                public int LPB;
            }
            #endregion

            public event NowSlowStorage NowSlowEvent;

            [Header("譜面"), SerializeField]
            private TextAsset scoreData;//譜面のjson


            [Header("判定場所"), SerializeField]
            private GameObject judgePlace;
            [SerializeField]
            private GameObject insPlace;

            [Header("それぞれのprefab"), SerializeField]
            private GameObject firstObj;
            [SerializeField]
            private GameObject vegetableObj;
            [SerializeField]
            private GameObject meetObj;
            [SerializeField]
            private GameObject keyObj;
            [SerializeField]
            private GameObject dustObj;
            [SerializeField]
            private GameObject inputDeleagate2Obj;

            [SerializeField]
            private AudioSource gameAudio;

            private int[] scoreNum;//音符の番号を順に入れる
            private int[] scoreBlock;//音符の種類を順に入れる
            private int BPM;//音符の種類を順に入れる
            private int LPB;//音符の種類を順に入れる

            private float moveSpan = 0.01f;
            private float nowTime;// 音再生時間
            private int beatNum;// 今の拍数
            private int beatCount;// json配列用(拍数)のカウント
            private bool isBeat;// ビートを打っているか(生成のタイミング)

            private FirstObjectPool firstObjectPool;//野菜のオブジェクトプール
            private VegetableObjectPool vegetableObjectPool;//野菜のオブジェクトプール
            private MeetObjectPool meetObjectPool;//野菜のオブジェクトプール
            private KeyObjectPool keyObjectPool;//野菜のオブジェクトプール
            private DustObjectPool dustObjectPool;//野菜のオブジェクトプール
            private const int First_MAX = 1;//野菜の最高生成個数
            private const int Vegetable_MAX = 5;//野菜の最高生成個数
            private const int Meet_MAX = 5;//肉の最高生成個数
            private const int Key_MAX = 5;//鍵の最高生成個数
            private const int Dust_MAX = 5;//鍵の最高生成個数

            public Vector2 StartPos { get; private set; }
            public Vector2 EndPos { get; private set; }

            public void Awake()
            {
                MusicReading();

                StartPos = new Vector2(insPlace.transform.position.x, insPlace.transform.position.y);
                EndPos = new Vector2(judgePlace.transform.position.x, judgePlace.transform.position.y);

                firstObjectPool = GetComponent<FirstObjectPool>();
                firstObjectPool.CreatePool(firstObj, First_MAX);
                vegetableObjectPool = GetComponent<VegetableObjectPool>();
                vegetableObjectPool.CreatePool(vegetableObj, Vegetable_MAX);
                meetObjectPool = GetComponent<MeetObjectPool>();
                meetObjectPool.CreatePool(meetObj, Meet_MAX);
                keyObjectPool = GetComponent<KeyObjectPool>();
                keyObjectPool.CreatePool(keyObj, Key_MAX);
                dustObjectPool = GetComponent<DustObjectPool>();
                dustObjectPool.CreatePool(dustObj, Dust_MAX);



                InvokeRepeating("MaterialIns", 0, moveSpan);
            }

            void MaterialIns()
            {
                GetScoreTime();
                NotesIns();
                AudioPlay(Guzai_move.isAudioPlay);
            }

            /// <summary>
            /// 譜面の読み込み
            /// </summary>
            void MusicReading()
            {
                string inputString = scoreData.ToString();// stringにデーターを変換
                InputJson inputJson = JsonUtility.FromJson<InputJson>(inputString);// クラスと値をやりとりする

                scoreNum = new int[inputJson.notes.Length];//NullRef吐くから要素数固定する
                scoreBlock = new int[inputJson.notes.Length];//NullRef吐くから要素数固定する
                BPM = inputJson.BPM;
                LPB = inputJson.notes[0].LPB;

                // numをコピーしてほかのスクリプトから呼び出せるようにする
                for (int i = 0; i < inputJson.notes.Length; i++)
                {
                    scoreNum[i] = inputJson.notes[i].num;
                    scoreBlock[i] = inputJson.notes[i].block;
                }

            }

            /// <summary>
            /// 譜面上の時間とゲームの時間のカウントと制御
            /// </summary>
            void GetScoreTime()
            {
                nowTime += moveSpan;// 今の音楽の時間の取得

                if (beatCount > scoreNum.Length) return;

                beatNum = (int)(nowTime * BPM / 60 * LPB);// 楽譜上でどこかの取得
            }

            /// <summary>
            /// ノーツを生成する
            /// </summary>
            void NotesIns()
            {
                if (beatCount < scoreNum.Length) isBeat = (scoreNum[beatCount] == beatNum);// json上でのカウントと楽譜上でのカウントの一致

                //生成のタイミングなら
                if (isBeat)
                {
                    //ノーツの生成(フラグ)
                    if (scoreBlock[beatCount] == 0)
                    {
                        firstObjectPool.GetObject();
                    }

                    //ノーツの生成(野菜)
                    if (scoreBlock[beatCount] == 1)
                    {
                        vegetableObjectPool.GetObject();
                    }

                    //ノーツの生成(肉)
                    else if (scoreBlock[beatCount] == 2)
                    {
                        meetObjectPool.GetObject();
                    }

                    //ノーツの生成(鍵)
                    else if (scoreBlock[beatCount] == 3)
                    {
                        keyObjectPool.GetObject();
                    }

                    //ノーツの生成(ごみ)
                    else if (scoreBlock[beatCount] == 4)
                    {
                        dustObjectPool.GetObject();
                    }

                    beatCount++;
                    isBeat = false;

                }
            }

            void AudioPlay(bool _flag)
            {
                if (_flag)
                {
                    gameAudio.enabled = true;
                }
            }
        }

    }
}

