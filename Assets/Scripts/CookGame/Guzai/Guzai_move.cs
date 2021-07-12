using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using sakuGame.Guzai;
using sakuGame;
using sakuGame.BGM;

public class Guzai_move : MonoBehaviour,IJudgeEndTime
{
    // オブジェクト情報
    // 具材オブジェクト
    [SerializeField]
    private GameObject guzai;
    // 具材の座標値
    private Vector2 guzaiPos;
    // 代入するx座標とy座標
    private float x;
    private float y;
    // 始点オブジェクトと終点オブジェクト
    [SerializeField]
    [Header("始点")]
    private GameObject startObj;
    [SerializeField]
    [Header("終点")]
    private GameObject endObj;
    // 始点→終点の距離
    private float xDist;

    // 斜方投射に必要な情報
    // 時間
    // 現在の時間
    private float time;
    // 演算を繰り返す時間
    private float loopTime = 0.01f;
    // フレーム数
    private const float FREAM = 60f;

    // 速度
    // y方向の速度
    private float speedY;
    // 重力加速度
    private const float GRAVITY = 9.8f;

    // 角度
    [SerializeField]
    [Range(0f, 90f)]
    [Header("角度")]
    private float deg = 30f;
    private float sin;

    // 終点時間と初速度
    [SerializeField]
    [Header("終点時間と初速度取得用のデータベース")]
    private MoveData moveData;

    public static bool isAudioPlay = false;
    private float notesTime = 0;
    private sakuGame.BGM.GuzaiGenerator guzaiGenerator;

    [SerializeField]
    private Sprite[] guzaiImage;
    [SerializeField]
    private Sprite[] guzaiCutImage;

    private CutObjRObjectPool cutR;
    private CutObjLObjectPool1 cutL;
    [SerializeField]
    private GameObject cutRObj;
    [SerializeField]
    private GameObject cutLObj;

    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip[] SE;

    int guzaiNum;

    public event JudgeTimeEndStorage JudgeTime;//あまかすすーぱーイベント
    public event NowMeetCut MeetCutEvent;
    public event RhythmTimingStorage RhythmTimingEvent;
    public event NowSlowStorage NowSlowEvent;

    private bool IsCut;//切られた野菜かどうか

    private void Awake()
    {
        guzaiGenerator = GameObject.Find("GuzaiGenerator").GetComponent<sakuGame.BGM.GuzaiGenerator>();
        startObj.transform.position = new Vector2(guzaiGenerator.StartPos.x, guzaiGenerator.StartPos.y);
        endObj.transform.position = new Vector2(guzaiGenerator.EndPos.x, guzaiGenerator.EndPos.y);

        // 具材の座標値を始点の座標値に合わせる
        guzai.transform.position = startObj.transform.position;

        // 具材の座標値を保存
        guzaiPos = guzai.transform.position;

        // sinθ定義
        sin = Mathf.Sin(deg * Mathf.Deg2Rad);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = guzaiImage[UnityEngine.Random.Range(0, guzaiImage.Length)];
    }

    void Start()
    {
        time = 0;
        InvokeRepeating("PositionMove", 0f, loopTime);

        cutR = GetComponent<CutObjRObjectPool>();
        cutR.CreatePool(cutRObj, 5);
        cutL = GetComponent<CutObjLObjectPool1>();
        cutL.CreatePool(cutLObj, 5);
    }

    void PositionMove()
    {
        if (this.gameObject.activeSelf)
        {
            // 時間定義
            time += loopTime;

            xDist = 6.5f;

            x -= xDist / (60.0f / 130.0f * 4) / FREAM;
            y = -0.6f * (x + guzaiPos.x - 3.0f) * (x + guzaiPos.x - 3.0f) + 8;

            guzai.transform.position = new Vector2(x + guzaiPos.x, y + guzaiPos.y);

            notesTime = (60.0f / 130.0f * 4) - time;

            NotesJudge();

        }


    }

    void NotesJudge()
    {

        switch (this.gameObject.tag)
        {
            case "First":
                FirstNotes();
                break;
            case "Ve":
                GuzaiJude();
                break;
            case "Meet":
                GuzaiJude();
                break;
            case "Key":
                GuzaiJude();
                break;
            case "Dust":
                TrushJudge();
                break;
        }


    }

    void FirstNotes()
    {
        if (notesTime <= 0.0f)//カウントダウンした時間が0になったら
        {
            isAudioPlay = true;

            transform.position = new Vector3(startObj.transform.position.x, startObj.transform.position.y, 0f);
            RecyclingInitialization();
            this.gameObject.SetActive(false);
        }
    }

    void GuzaiJude()
    {
        
        //一拍の30%秒の時間判定可能
        if (Math.Abs(notesTime) <= 60.0f / 130.0f * 0.4f)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                cutR.GetObject();
                //cutRObj.GetComponent<SpriteRenderer>().sprite = guzaiCutImage[guzaiNum * 2];
                cutL.GetObject();
                //cutLObj.GetComponent<SpriteRenderer>().sprite = guzaiCutImage[guzaiNum * 2 + 1];

                audio.PlayOneShot(SE[0]);

                RecyclingInitialization();
                this.gameObject.SetActive(false);
                //CallJudgeEndEvent(guzai.GetComponent<Guzai_Core>().GetItemName(), true);//スコア送る
                if(guzai.GetComponent<Guzai_Core>().GetItemName()==ItemNames.Meat)
                {
                    MeetCutEvent();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //はじいた具材生成

                audio.PlayOneShot(SE[1]);

                RecyclingInitialization();
                this.gameObject.SetActive(false);
            }
        }
        else if (notesTime < 60.0f / 130.0f * -0.4f)
        {
            //CallJudgeEndEvent(guzai.GetComponent<Guzai_Core>().GetItemName(), false);//スコア送る
            RecyclingInitialization();
            this.gameObject.SetActive(false);
        }


    }

    void TrushJudge()
    {
      
        //一拍の30%秒の時間判定可能
        if (Math.Abs(notesTime) <= 60.0f / 130.0f * 0.4f)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                cutR.GetObject();
                //cutRObj.GetComponent<SpriteRenderer>().sprite = guzaiCutImage[guzaiNum * 2];
                cutL.GetObject();
                //cutLObj.GetComponent<SpriteRenderer>().sprite = guzaiCutImage[guzaiNum * 2 + 1];

                audio.PlayOneShot(SE[0]);

                RecyclingInitialization();
                this.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //はじいた具材生成

                audio.PlayOneShot(SE[1]);

                RecyclingInitialization();
                this.gameObject.SetActive(false);
            }
        }
        else if (notesTime < 60.0f / 130.0f * -0.4f)
        {
            //入れた具材生成

            RecyclingInitialization();
            this.gameObject.SetActive(false);
        }
    }
    //public void CallJudgeEndEvent(ItemNames itemNames, bool isslash)//これを呼ぶとスコア送ってくれる
    //{
    //    JudgeTime(itemNames, isslash);//データを送るぞ
    //}

    /// <summary>
    /// もう一度利用する為に初期化しておく必要があるもの
    /// </summary>
    void RecyclingInitialization()
    {
        time = 0;
        x = 0;
        y = 0;
        guzai.transform.position = new Vector2(startObj.transform.position.x, startObj.transform.position.y);
        guzaiPos = startObj.transform.position;
        guzaiNum = UnityEngine.Random.Range(0, guzaiImage.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = guzaiImage[guzaiNum];
    }
}
