using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Result
{
    public class ShowResult : MonoBehaviour
    {
        // カレーの名前とか画像のデータ
        // enum CurryRankと同じ並び
        [SerializeField]
        CurryData[] currys;

        // スコア評価のスクリプト
        ResultScoreCalc resScoCal;

        private int rank = 0;
        private string namedTrashText;
        private string curryName;
        private Sprite currySprite;

        // ごみを表示するためのフラグ
        private byte trashFlag0b;
        private bool getaActive = false;
        private bool maskActive = false;
        private bool utiwaActive = false;


        // ごみの名前を表示するtextコンポーネント
        [Header("Text"), SerializeField]
        Text trashTextComp;
        // カレーの名前を表示する〃
        [SerializeField]
        Text curryTextComp;

        // カレーの画像を表示するimageコンポーネント
        [Header("Image"), SerializeField]
        Image curryImageComp;
        // 背景の光
        [SerializeField]
        Image flashImageComp;
        // ごみ3つのimageコンポーネント
        [SerializeField]
        Image GetaImageComp, MaskImageComp, UtiwaImageComp;

        void Start()
        {
            resScoCal = GetComponent<ResultScoreCalc>();

            // 評価を取得する
            rank = (int)resScoCal.GetCurryRank();
            // ごみの文字列を取得する
            namedTrashText = resScoCal.GetTrashNameText();
            // フラグを取得する
            trashFlag0b = resScoCal.GetTrashFlag();
            ImportFlags();

            // カレーの名前と画像を読み込む
            curryName = currys[rank].curryName;
            currySprite = currys[rank].image;

            // UIに反映する
            trashTextComp.text = namedTrashText;
            curryTextComp.text = curryName;
            curryImageComp.sprite = currySprite;
            // ごみの表示
            GetaImageComp.enabled = getaActive;
            MaskImageComp.enabled = maskActive;
            UtiwaImageComp.enabled = utiwaActive;

            if(rank == (int)CurryRank.S)
            {
                flashImageComp.enabled = true;
                flashImageComp.color = new Color(1, 1, 1, 1 * 120 / 255f);
            }
            else if (rank == (int)CurryRank.A)
            {
                flashImageComp.enabled = true;
                flashImageComp.color = new Color(1, 1, 1, 1 * 50 / 255f);
            }
            else
            {
                flashImageComp.enabled = false;
            }

        }

        // 2進数のフラグを単体のboolに直す
        void ImportFlags()
        {
            if((trashFlag0b & 0b001) == 0b001)
            {
                getaActive = true;
            }
            if ((trashFlag0b & 0b010) == 0b010)
            {
                maskActive = true;
            }
            if ((trashFlag0b & 0b100) == 0b100)
            {
                utiwaActive = true;
            }
        }
    }
}
