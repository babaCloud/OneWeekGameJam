using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using sakuGame.InputSystem;
using sakuGame.BGM;

namespace sakuGame.Guzai
{

    public class CanSlashJudge : MonoBehaviour, IGuzaiSlash, IJudgeEndTime
    {
        [Inject]
        IInputer inputer;
    
        public event NowSlashStorage NowSlashEvent;//素材を切った時に走ったイベント
        public event JudgeTimeEndStorage JudgeTime;//野菜を切れる時間が終わったら発行　点数おくるよ

        [SerializeField] Guzai_Core core;
        bool CanSlash;
        const float CANSLASHTIME = 1.0f;
        private bool isSlashed;
        private float timecount;
        void Start()
        {
            inputer.InputEvent += GuzaiSlashed;
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void GuzaiSlashed(MouseClick mouseClick)//切られたときに割れる
        {
            if(mouseClick==MouseClick.LeftClick)
            {

            }
            else
            {

            }
        }
        public void CallJudgeEndEvent(ItemNames itemNames,bool isslash)
        {
            JudgeTime(itemNames,isslash);//データを送るぞ
        }

    }

}
