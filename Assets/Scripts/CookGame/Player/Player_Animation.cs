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
            [SerializeField] GameObject inputerObj;
            IInputer inputer;
            [Inject]
            IWhen_RhythmTiming rhythmTiming;
            private bool IsSlash;//���؂��Ă�����TRUE
            Animator animator;
            void Start()
            {
                inputer = inputerObj.GetComponent<IInputer>();
                inputer.InputEvent += SlashAnim;
                //rhythmTiming.RhythmTimingEvent += OnRhythm;
                IsSlash = false;
                animator = GetComponent<Animator>();
            }

            void Update()
            {
                
            }
            
            void SlashAnim(MouseClick mouseClick)//�{�^���������ꂽ�Ƃ�
            {
                if(!IsSlash)
                {
                    IsSlash = true;

                    animator.SetTrigger("Cut");

                    //�A�j���[�V����
                }
            }
            void OnRhythm()
            {
                if(IsSlash)//�؂��Ă�Ƃ��͂��Ȃ���
                {
                    //���ɂ�
                }
            }
           public void FinishCut()
            {
                IsSlash = false;
            }
        }

    }

}
