using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            // Start is called before the first frame update
            void Start()
            {
                inputer.InputEvent += SlashAnim;
            }

            // Update is called once per frame
            void Update()
            {

            }
            void SlashAnim(MouseClick mouseClick)//ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«
            {

            }
        }

    }

}
