using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAnyKey : MonoBehaviour
{
    [SerializeField]
    LoadSceneManager loadManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            loadManager.LoadScene("Game");
        }
    }
}
