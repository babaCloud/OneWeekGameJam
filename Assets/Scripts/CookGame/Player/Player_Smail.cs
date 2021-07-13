using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sakuGame.Guzai;
using Zenject;
public class Player_Smail : MonoBehaviour
{
    SpriteRenderer spr;
    [SerializeField]
    Sprite Normal;
    [SerializeField]
    Sprite Smail;
    [Inject]
    IMeetCut meetCut;
    bool isSmile;
    float Timecount;
        // Start is called before the first frame update
    void Start()
    {
        meetCut.MeetCutEvent+=SmileSpr;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSmile)
        {
            Timecount += Time.deltaTime;
        }
        if(Timecount>1.5f)
        {
            Timecount = 0;
            isSmile = false;
            spr.sprite = Normal;
        }
    }
    void SmileSpr()
    {
        if(!isSmile)
        {
            spr.sprite = Smail;
        }
    }
}
