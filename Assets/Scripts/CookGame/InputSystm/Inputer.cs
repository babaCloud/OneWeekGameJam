
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace sakuGame.InputSystem
{
    public class Inputer : MonoBehaviour, IInputer
    {

        public event InputDelgate InputEvent;

       
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputEvent(MouseClick.LeftClick);
            }
            if (Input.GetMouseButtonDown(1))
            {
                InputEvent(MouseClick.RightClick);
            }
        }
    }

}
