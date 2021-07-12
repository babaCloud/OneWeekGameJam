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
    
        public event NowSlashStorage NowSlashEvent;//�f�ނ�؂������ɑ������C�x���g
        public event JudgeTimeEndStorage JudgeTime;//��؂�؂�鎞�Ԃ��I������甭�s�@�_���������

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
        public void GuzaiSlashed(MouseClick mouseClick)//�؂�ꂽ�Ƃ��Ɋ����
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
            JudgeTime(itemNames,isslash);//�f�[�^�𑗂邼
        }

    }

}
