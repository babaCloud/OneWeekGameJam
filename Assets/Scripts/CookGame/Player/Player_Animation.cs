using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sakuGame.BGM;
using sakuGame.InputSystem;
using Zenject;
namespace sakuGame
{
    namespace Player
    {
        public class Player_Animation : MonoBehaviour
        {
            [Inject]
            IInputer inputer;
            [Inject]
            IWhen_RhythmTiming rhythmTiming;
            private bool IsSlash;//今切っていたらTRUE
            private int SlashAnimCount;
            Animator animator;
            void Start()
            {
                inputer.InputEvent += SlashAnim;
                rhythmTiming.RhythmTimingEvent += OnRhythm;
                IsSlash = false;
                animator = GetComponent<Animator>();
            }

            void Update()
            {

            }
            
            void SlashAnim(MouseClick mouseClick)//ボタンが押されたとき
            {
                if(!IsSlash)
                {
                    IsSlash = true;

                    animator.SetTrigger("Cut");

                    //アニメーション
                }
            }
            void OnRhythm()
            {
                if(IsSlash)//切ってるときはしないよ
                {
                    //あにめ
                }
            }
           public void FinishCut()
            {
                IsSlash = false;
            }
        }

    }

}
