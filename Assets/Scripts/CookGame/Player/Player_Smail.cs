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
    //[Inject]
    //IMeetCut meetCut;
    bool isSmile;
    float Timecount;
        // Start is called before the first frame update
    void Start()
    {
        //meetCut.MeetCutEvent+=SmileSpr;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSmile)
        {
            Timecount += Time.deltaTime;
        }
        if(Timecount>0.5f)
        {
            Timecount = 0;
            isSmile = false;
            spr.sprite = Normal;
        }
    }
    public void SmileSpr()
    {
        if(!isSmile)
        {
            Timecount = 0;
            spr.sprite = Smail;
        }
    }
}
