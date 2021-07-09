using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoEvent : MonoBehaviour,IInputerTest
{
    public event InputDeleagate2 InputEvent2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            InputEvent2(KeyEnum.Return);
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            InputEvent2(KeyEnum.Return);
        }
        else
        {
            InputEvent2(KeyEnum.Null);
        }
    }
}
