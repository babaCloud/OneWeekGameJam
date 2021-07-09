using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sakuGame.BGM
{
    public class TempoGenerator : MonoBehaviour,IWhen_RhythmTiming,IWhen_SlowTiming,IWhenEndBgm
   {
        public event RhythmTimingStorage RhythmTimingEvent;//はく来た時に呼んでほしい　主にキャラのアニメーション
        public event NowSlowStorage NowSlowEvent;//投げてほしい時に引数は投げたいやさい
        public event EndGameStorage EndGameEvent;//これ呼ぶとゲーム終わる

        // Start is called before the first frame update
        void Start()
        {
            //上のイベント達は
            //RhythmTimingEvent();
            //って漢字でメソッドと同じように呼べるぜ
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

