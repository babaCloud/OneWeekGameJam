using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guzai_move : MonoBehaviour
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
    [SerializeField][Header("始点")]
    private GameObject startObj;
    [SerializeField][Header("終点")]
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
    private const float frame = 60f;

    // 速度
    // y方向の速度
    private float speedY;
    // 重力加速度
    private const float GRAVITY = 9.8f;

    // 角度
    [SerializeField][Range(0f, 90f)][Header("角度")]
    private float deg = 30f;
    private float sin;

    // 終点時間と初速度
    [SerializeField][Header("終点時間と初速度取得用のデータベース")]
    private MoveData moveData;

    private void Awake()
    {
        // 具材の座標値を始点の座標値に合わせる
        guzai.transform.position = startObj.transform.position;

        // 具材の座標値を保存
        guzaiPos = guzai.transform.position;

        // sinθ定義
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
        

        // 時間定義
        time += Time.deltaTime;

        // 現在の速度を求める
        speedY = moveData.firstSpeed * sin - GRAVITY * time;

        // 斜方投射
        // x方向：等速直線運動
        xDist = Mathf.Abs(endObj.transform.position.x - startObj.transform.position.x);
        x += xDist / moveData.endTime / frame;
        // y方向：投げ上げ
        y = speedY * sin * time - (1 / 2 * GRAVITY * Mathf.Pow(time, 2));
        guzai.transform.position = new Vector2(guzaiPos.x + x, guzaiPos.y + y);
    }
}
