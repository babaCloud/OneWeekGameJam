using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Guzai_Core : MonoBehaviour
{
    private enum GuzaiName
    {
        Carrot,Potato,Etc
            ,Num
    }
    
    [SerializeField] private GuzaiName guzaiName;
    [Header("�؂���")]
    [SerializeField] private int SlashNum;
}
