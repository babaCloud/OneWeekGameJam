using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guzai_move : MonoBehaviour
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
    [SerializeField][Header("�n�_")]
    private GameObject startObj;
    [SerializeField][Header("�I�_")]
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
    private const float frame = 60f;

    // ���x
    // y�����̑��x
    private float speedY;
    // �d�͉����x
    private const float GRAVITY = 9.8f;

    // �p�x
    [SerializeField][Range(0f, 90f)][Header("�p�x")]
    private float deg = 30f;
    private float sin;

    // �I�_���ԂƏ����x
    [SerializeField][Header("�I�_���ԂƏ����x�擾�p�̃f�[�^�x�[�X")]
    private MoveData moveData;

    private void Awake()
    {
        // ��ނ̍��W�l���n�_�̍��W�l�ɍ��킹��
        guzai.transform.position = startObj.transform.position;

        // ��ނ̍��W�l��ۑ�
        guzaiPos = guzai.transform.position;

        // sin�ƒ�`
        sin = Mathf.Sin(deg * Mathf.Deg2Rad);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PositionMove", 0f, loopTime);
    }

    // Update is called once per frame
    void Update()
    {
        

        // ���Ԓ�`
        time += Time.deltaTime;

        // ���݂̑��x�����߂�
        speedY = moveData.firstSpeed * sin - GRAVITY * time;

        // �Ε�����
        // x�����F���������^��
        xDist = Mathf.Abs(endObj.transform.position.x - startObj.transform.position.x);
        x += xDist / moveData.endTime / frame;
        // y�����F�����グ
        y = speedY * sin * time - (1 / 2 * GRAVITY * Mathf.Pow(time, 2));
        guzai.transform.position = new Vector2(guzaiPos.x + x, guzaiPos.y + y);
    }
}
