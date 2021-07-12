using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move_logo : MonoBehaviour
{
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.DOLocalMoveY(200f, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {

    }
}
