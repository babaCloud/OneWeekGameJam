using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sakuGame.BGM
{
    public class TempoGenerator : MonoBehaviour,IWhen_RhythmTiming,IWhen_SlowTiming,IWhenEndBgm
   {
        public event RhythmTimingStorage RhythmTimingEvent;//�͂��������ɌĂ�łق����@��ɃL�����̃A�j���[�V����
        public event NowSlowStorage NowSlowEvent;//�����Ăق������Ɉ����͓��������₳��
        public event EndGameStorage EndGameEvent;//����ĂԂƃQ�[���I���

        // Start is called before the first frame update
        void Start()
        {
            //��̃C�x���g�B��
            //RhythmTimingEvent();
            //���Ċ����Ń��\�b�h�Ɠ����悤�ɌĂׂ邺
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

