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


        public event NowSlashStorage NowSlashEvent;//�f�ނ�؂������ɑ������C�x���g
        public event JudgeTimeEndStorage JudgeTime;//��؂�؂�鎞�Ԃ��I������甭�s�@�_���������


        // Start is called before the first frame update
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

        }
    }

}
