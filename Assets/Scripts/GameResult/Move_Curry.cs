using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move_Curry : MonoBehaviour
{
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOMove(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.OutBounce).SetDelay(0.8f).OnComplete(() =>
        {
            rectTransform.DOLocalMoveY(30, 1).SetLoops(-1, LoopType.Yoyo);
        });
    }

    void Update()
    {
        
    }
}
