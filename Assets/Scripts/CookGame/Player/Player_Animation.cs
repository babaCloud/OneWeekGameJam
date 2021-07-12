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
            // Start is called before the first frame update
            void Start()
            {
                inputer.InputEvent += SlashAnim;
                rhythmTiming.RhythmTimingEvent += OnRhythm;
                IsSlash = false;
            }

            // Update is called once per frame
            void Update()
            {

            }
            
            void SlashAnim(MouseClick mouseClick)//ボタンが押されたとき
            {
                if(!IsSlash)
                {
                    IsSlash = false;
                    //アニメーション
                    StartCoroutine(AttackAnim());
                }
            }
            void OnRhythm()
            {
                
            }
            IEnumerator AttackAnim()
            {
                yield return new WaitForSeconds(1);

            }
        }

    }

}
