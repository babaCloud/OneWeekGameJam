using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject  inputerObj;
    IInputer inputerTest;
    // Start is called before the first frame update
    void Start()
    {
        inputerTest = inputerObj.GetComponent<IInputer>();
        inputerTest.InputEvent += testman;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void testman(MouseClick mouseClick)
    {
        if(mouseClick==MouseClick.LeftClick)
        {
            Debug.Log("‚Ð‚¾‚è");
        }
        else if(mouseClick == MouseClick.RightClick)
        {
            Debug.Log("‚Ý‚¬");
        }
    }
}
