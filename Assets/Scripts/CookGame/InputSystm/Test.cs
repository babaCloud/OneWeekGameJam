using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Test : MonoBehaviour
{
    [Inject]
    sakuGame.InputSystem.IInputer inputer;
    // Start is called before the first frame update
    void Start()
    {
        inputer.InputEvent += Eve;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Eve(sakuGame.InputSystem.MouseClick mouseClick)
    {
        if(mouseClick==sakuGame.InputSystem.MouseClick.LeftClick)
        {
            Debug.Log("‚Ð‚¾‚è");
        }
        else
        {
            Debug.Log("‚Ý‚¬");
        }
    }
}
