using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTitle : MonoBehaviour
{
    [SerializeField]
    LoadSceneManager loadManager;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            loadManager.LoadScene("Title");
        }
    }
}
