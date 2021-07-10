using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Result
{
    public class ShowResult : MonoBehaviour
    {
        [SerializeField]
        CurryData[] currys;

        ResultScoreCalc resScoCal;

        int rank = 0;
        string plusNamed;
        string curryName;
        Sprite currySprite;

        [SerializeField]
        Text plusText;
        [SerializeField]
        Text curryText;
        [SerializeField]
        Image curryImage;

        void Start()
        {
            resScoCal = GetComponent<ResultScoreCalc>();

            rank = resScoCal.GetRank();
            plusNamed = resScoCal.GetPlusNamed();

            curryName = currys[rank].curryName;
            currySprite = currys[rank].image;

            plusText.text = plusNamed;
            curryText.text = curryName;
            curryImage.sprite = currySprite;
        }
    }
}
