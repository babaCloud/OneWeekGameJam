using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using sakuGame.Guzai;
using sakuGame;
using sakuGame.BGM;

public class Guzai_move : MonoBehaviour,IJudgeEndTime,IMeetCut,IWhen_RhythmTiming,IWhen_SlowTiming
{
    // �I�u�W�F�N�g���
    // ��ރI�u�W�F�N�g
    [SerializeField]
    private GameObject guzai;
    // ��ނ̍��W�l
    private Vector2 guzaiPos;
    // �������x���W��y���W
    private float x;
    private float y;
    // �n�_�I�u�W�F�N�g�ƏI�_�I�u�W�F�N�g
    [SerializeField]
    [Header("�n�_")]
    private GameObject startObj;
    [SerializeField]
    [Header("�I�_")]
    private GameObject endObj;
    // �n�_���I�_�̋���
    private float xDist;

    // �Ε����˂ɕK�v�ȏ��
    // ����
    // ���݂̎���
    private float time;
    // ���Z���J��Ԃ�����
    private float loopTime = 0.01f;
    // �t���[����
    private const float FREAM = 60f;

    // ���x
    // y�����̑��x
    private float speedY;
    // �d�͉����x
    private const float GRAVITY = 9.8f;

    // �p�x
    [SerializeField]
    [Range(0f, 90f)]
    [Header("�p�x")]
    private float deg = 30f;
    private float sin;

    // �I�_���ԂƏ����x
    [SerializeField]
    [Header("�I�_���ԂƏ����x�擾�p�̃f�[�^�x�[�X")]
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

    public event JudgeTimeEndStorage JudgeTime;//���܂������[�ρ[�C�x���g
    public event NowMeetCut MeetCutEvent;
    public event RhythmTimingStorage RhythmTimingEvent;
    public event NowSlowStorage NowSlowEvent;

    private bool IsCut;//�؂�ꂽ��؂��ǂ���

    private void Awake()
    {
        guzaiGenerator = GameObject.Find("GuzaiGenerator").GetComponent<sakuGame.BGM.GuzaiGenerator>();
        startObj.transform.position = new Vector2(guzaiGenerator.StartPos.x, guzaiGenerator.StartPos.y);
        endObj.transform.position = new Vector2(guzaiGenerator.EndPos.x, guzaiGenerator.EndPos.y);

        // ��ނ̍��W�l���n�_�̍��W�l�ɍ��킹��
        guzai.transform.position = startObj.transform.position;

        // ��ނ̍��W�l��ۑ�
        guzaiPos = guzai.transform.position;

        // sin�ƒ�`
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
            // ���Ԓ�`
            time += Time.deltaTime;

            // ���݂̑��x�����߂�
            speedY = moveData.firstSpeed * sin - GRAVITY * time;

            // �Ε�����
            // x�����F���������^��
            xDist = Mathf.Abs(endObj.transform.position.x - startObj.transform.position.x);
            x -= xDist / moveData.endTime / FREAM;
            // y�����F�����グ
            y = speedY * sin * time - (1 / 2 * GRAVITY * Mathf.Pow(time, 2));
            guzai.transform.position = new Vector2(guzaiPos.x + x, guzaiPos.y + y);

            notesTime = moveData.endTime - time - 0.5f;

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
        if (notesTime <= 0.0f)//�J�E���g�_�E���������Ԃ�0�ɂȂ�����
        {
            isAudioPlay = true;

            transform.position = new Vector3(startObj.transform.position.x, startObj.transform.position.y, 0f);
            RecyclingInitialization();
            this.gameObject.SetActive(false);
        }
    }

    void GuzaiJude()
    {
        //�}�W�b�N�i���o�[�S�����ق�Ƃɂ��߂�
        bool isOK = Math.Abs(guzai.transform.position.x - endObj.transform.position.x) < 1.5f &&
                    Math.Abs(guzai.transform.position.y - endObj.transform.position.y) < 1.5f + 2.671417f;
        bool isNO = (guzai.transform.position.x - endObj.transform.position.x) < -1.5f &&
                    (guzai.transform.position.y - endObj.transform.position.y) < -1.5f + 2.671417f;

        //�ꔏ��30%�b�̎��Ԕ���\
        if (isOK)
        {
            Debug.Log("ok");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                cutR.GetObject();
                //cutRObj.GetComponent<SpriteRenderer>().sprite = guzaiCutImage[guzaiNum * 2];
                cutL.GetObject();
                //cutLObj.GetComponent<SpriteRenderer>().sprite = guzaiCutImage[guzaiNum * 2 + 1];

                audio.PlayOneShot(SE[0]);

                Debug.Log("cut");
                RecyclingInitialization();
                this.gameObject.SetActive(false);
                CallJudgeEndEvent(guzai.GetComponent<Guzai_Core>().GetItemName(), true);//�X�R�A����
                if(guzai.GetComponent<Guzai_Core>().GetItemName()==ItemNames.Meat)
                {
                    MeetCutEvent();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //�͂�������ސ���

                audio.PlayOneShot(SE[1]);

                Debug.Log("haji");
                RecyclingInitialization();
                this.gameObject.SetActive(false);
            }
        }
        else if (isNO)
        {
            Debug.Log("in");
            CallJudgeEndEvent(guzai.GetComponent<Guzai_Core>().GetItemName(), false);//�X�R�A����
            RecyclingInitialization();
            this.gameObject.SetActive(false);
        }


    }

    void TrushJudge()
    {
        bool isOK = Math.Abs(guzai.transform.position.x - endObj.transform.position.x) < 1.5f &&
                    Math.Abs(guzai.transform.position.y - endObj.transform.position.y) < 1.5f + 2.671417f;
        bool isNO = (guzai.transform.position.x - endObj.transform.position.x) < -1.5f &&
                    (guzai.transform.position.y - endObj.transform.position.y) < -1.5f + 2.671417f;

        //�ꔏ��30%�b�̎��Ԕ���\
        if (isOK)
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
                //�͂�������ސ���

                audio.PlayOneShot(SE[1]);

                RecyclingInitialization();
                this.gameObject.SetActive(false);
            }
        }
        else if (isNO)
        {
            //���ꂽ��ސ���

            RecyclingInitialization();
            this.gameObject.SetActive(false);
        }
    }
    public void CallJudgeEndEvent(ItemNames itemNames, bool isslash)//������ĂԂƃX�R�A�����Ă����
    {
        JudgeTime(itemNames, isslash);//�f�[�^�𑗂邼
    }

    /// <summary>
    /// ������x���p����ׂɏ��������Ă����K�v���������
    /// </summary>
    void RecyclingInitialization()
    {
        Debug.Log(notesTime);
        time = 0;
        x = 0;
        y = 0;
        guzai.transform.position = new Vector2(startObj.transform.position.x, startObj.transform.position.y);
        guzaiPos = startObj.transform.position;
        guzaiNum = UnityEngine.Random.Range(0, guzaiImage.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = guzaiImage[guzaiNum];
    }
}
