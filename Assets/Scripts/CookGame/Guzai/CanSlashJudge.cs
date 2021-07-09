using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using sakuGame.InputSystem;

namespace sakuGame.Guzai
{


    public class CanSlashJudge : MonoBehaviour, IGuzaiSlash, IJudgeEndTime
    {
        [Inject]
        IInputer inputer;


        public event NowSlashStorage NowSlashEvent;//素材を切った時に走ったイベント
        public event JudgeTimeEndStorage JudgeTime;//野菜を切れる時間が終わったら発行　点数おくるよ


        // Start is called before the first frame update
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

        }
    }

}
