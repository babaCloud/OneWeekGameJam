using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBackFlash : MonoBehaviour
{
    RectTransform rectTf;
    private void Start()
    {
        rectTf = GetComponent<RectTransform>();
    }
    void Update()
    {
        rectTf.Rotate(0, 0, 1);
    }
}
