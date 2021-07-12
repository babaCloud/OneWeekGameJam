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
        rectTransform.DOMove(new Vector2(0, 0), 0.8f).SetEase(Ease.OutBounce).SetDelay(0.8f);
    }

    void Update()
    {
        
    }
}
