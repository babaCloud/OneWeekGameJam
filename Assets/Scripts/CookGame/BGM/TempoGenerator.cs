using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sakuGame.BGM
{
    public class TempoGenerator : MonoBehaviour,IWhen_RhythmTiming,IWhen_SlowTiming,IWhenEndBgm
   {
        public event RhythmTimingStorage RhythmTimingEvent;
        public event NowRhythmStorage NowRhythmEvent;
        public event EndGameStorage EndGameEvent;

        // Start is called before the first frame update
        void Start()
        {
            //��̃C�x���g�B��
            RhythmTimingEvent();
            //���Ċ����Ń��\�b�h�Ɠ����悤�ɌĂׂ邺
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

