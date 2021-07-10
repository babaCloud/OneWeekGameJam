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
            #region json��num��ǂݍ��݂���
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

            [Header("����"), SerializeField]
            private TextAsset scoreData;//���ʂ�json


            [Header("����ꏊ"), SerializeField]
            private GameObject judgePlace;
            [SerializeField]
            private GameObject insPlace;

            [Header("���ꂼ���prefab"), SerializeField]
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

            private int[] scoreNum;//�����̔ԍ������ɓ����
            private int[] scoreBlock;//�����̎�ނ����ɓ����
            private int BPM;//�����̎�ނ����ɓ����
            private int LPB;//�����̎�ނ����ɓ����

            private float moveSpan = 0.01f;
            private float nowTime;// ���Đ�����
            private int beatNum;// ���̔���
            private int beatCount;// json�z��p(����)�̃J�E���g
            private bool isBeat;// �r�[�g��ł��Ă��邩(�����̃^�C�~���O)

            private FirstObjectPool firstObjectPool;//��؂̃I�u�W�F�N�g�v�[��
            private VegetableObjectPool vegetableObjectPool;//��؂̃I�u�W�F�N�g�v�[��
            private MeetObjectPool meetObjectPool;//��؂̃I�u�W�F�N�g�v�[��
            private KeyObjectPool keyObjectPool;//��؂̃I�u�W�F�N�g�v�[��
            private DustObjectPool dustObjectPool;//��؂̃I�u�W�F�N�g�v�[��
            private const int First_MAX = 1;//��؂̍ō�������
            private const int Vegetable_MAX = 5;//��؂̍ō�������
            private const int Meet_MAX = 5;//���̍ō�������
            private const int Key_MAX = 5;//���̍ō�������
            private const int Dust_MAX = 5;//���̍ō�������

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
            /// ���ʂ̓ǂݍ���
            /// </summary>
            void MusicReading()
            {
                string inputString = scoreData.ToString();// string�Ƀf�[�^�[��ϊ�
                InputJson inputJson = JsonUtility.FromJson<InputJson>(inputString);// �N���X�ƒl�����Ƃ肷��

                scoreNum = new int[inputJson.notes.Length];//NullRef�f������v�f���Œ肷��
                scoreBlock = new int[inputJson.notes.Length];//NullRef�f������v�f���Œ肷��
                BPM = inputJson.BPM;
                LPB = inputJson.notes[0].LPB;

                // num���R�s�[���Ăق��̃X�N���v�g����Ăяo����悤�ɂ���
                for (int i = 0; i < inputJson.notes.Length; i++)
                {
                    scoreNum[i] = inputJson.notes[i].num;
                    scoreBlock[i] = inputJson.notes[i].block;
                }

            }

            /// <summary>
            /// ���ʏ�̎��ԂƃQ�[���̎��Ԃ̃J�E���g�Ɛ���
            /// </summary>
            void GetScoreTime()
            {
                nowTime += moveSpan;// ���̉��y�̎��Ԃ̎擾

                if (beatCount > scoreNum.Length) return;

                beatNum = (int)(nowTime * BPM / 60 * LPB);// �y����łǂ����̎擾
            }

            /// <summary>
            /// �m�[�c�𐶐�����
            /// </summary>
            void NotesIns()
            {
                if (beatCount < scoreNum.Length) isBeat = (scoreNum[beatCount] == beatNum);// json��ł̃J�E���g�Ɗy����ł̃J�E���g�̈�v

                //�����̃^�C�~���O�Ȃ�
                if (isBeat)
                {
                    //�m�[�c�̐���(�t���O)
                    if (scoreBlock[beatCount] == 0)
                    {
                        firstObjectPool.GetObject();
                    }

                    //�m�[�c�̐���(���)
                    if (scoreBlock[beatCount] == 1)
                    {
                        vegetableObjectPool.GetObject();
                    }

                    //�m�[�c�̐���(��)
                    else if (scoreBlock[beatCount] == 2)
                    {
                        meetObjectPool.GetObject();
                    }

                    //�m�[�c�̐���(��)
                    else if (scoreBlock[beatCount] == 3)
                    {
                        keyObjectPool.GetObject();
                    }

                    //�m�[�c�̐���(����)
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

