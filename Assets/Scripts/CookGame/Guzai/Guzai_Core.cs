using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Guzai_Core : MonoBehaviour
{
    [SerializeField] private sakuGame.ItemNames guzaiName;
    
    [Header("�؂���")]
    [SerializeField] private int SlashNum;
    public sakuGame.ItemNames GetItemName()
    {
        return guzaiName;
    }
}
