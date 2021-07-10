using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sakuGame;

namespace Result
{
    public enum CurryRank
    {
        S,  // パーフェクト
        A,
        B,
        C,
        O,  // おかゆ
        G   // ごみ
    }

    public class ResultScoreCalc : MonoBehaviour
    {
        [SerializeField]
        ScoreData scoreData;

        // ポイント
        private int score = 0;
        // 最大ポイント
        private int maxScore = 0;
        // 入ったごみの数
        private int inTrash = 0;
        // 投げられるごみの数
        private int maxTrash = 0;
        // 鍋に入ったごみのリスト
        private List<ItemNames> trashList = new List<ItemNames>(16);
        // ルーが入ったか
        private bool isInRoux = false;

        // 名付きごみが入ってるか
        private bool isInGeta = false;
        private bool isInMask = false;
        private bool isInUtiwa = false;

        // カレーのランク
        private CurryRank rank;
        // 付加用の名前リスト
        private List<string> trashNamedList = new List<string>(4);

        void Awake()
        {

            // データを読み取る
            this.score = scoreData.ResultScore;
            this.maxScore = scoreData.MaxScore;
            this.inTrash = scoreData.InTrash;
            this.maxTrash = scoreData.MaxTrash;
            this.trashList = scoreData.TrashList;
            this.isInRoux = scoreData.IsInRoux;

            rank = ScoreCheck();
            NamedCheck();
        }

        public int GetRank()
        {
            return (int)rank;
        }

        public string GetPlusNamed()
        {
            int namedNum = trashNamedList.Count;
            string plusNamed = "";
            for (int i = 0; i < namedNum; i++)
            {
                plusNamed += trashNamedList[i];
                if (i == namedNum - 1)
                {
                    plusNamed += "入り";
                }
                else
                {
                    plusNamed += "と";
                }
            }

            return plusNamed;
        }


        // 名を冠するリスト
        void NamedCheck()
        {
            int namedTrashNum = trashList.Count;

            // ごみリストをチェックして
            // 重複のないstringのリストを作る(重そう)
            if (namedTrashNum != 0)
            {
                for (int i = 0; i < namedTrashNum; i++)
                {
                    switch (trashList[i])
                    {
                        case ItemNames.Geta:
                            isInGeta = true;
                            break;
                        case ItemNames.Mask:
                            isInMask = true;
                            break;
                        case ItemNames.Utiwa:
                            isInUtiwa = true;
                            break;
                    }

                    // 3種類入ってるのを確認した時点でbreak
                    if (isInGeta && isInMask && isInUtiwa)
                    {
                        break;
                    }
                }

                if (isInGeta)
                {
                    trashNamedList.Add("下駄");
                }
                if (isInMask)
                {
                    trashNamedList.Add("マスク");
                }
                if (isInUtiwa)
                {
                    trashNamedList.Add("うちわ");
                }
            }
        }

        CurryRank ScoreCheck()
        {
            // スコア評価
            // パーフェクト!!
            if (score == maxScore)
            {
                return CurryRank.S;
            }
            // 何も入ってない(野菜もごみもルーも)
            else if (score == 0 && inTrash == 0 && !isInRoux)
            {
                return CurryRank.O;
            }
            // ごみばかり(スコアがマイナス)
            else if (score < 0)
            {
                return CurryRank.G;
            }
            // 3/4以上 かつ ゴミが入ってない
            else if (score >= maxScore * 0.75f && inTrash == 0)
            {
                return CurryRank.A;
            }
            // 2/4以上
            else if (score >= maxScore * 0.5f)
            {
                return CurryRank.B;
            }
            // 2/4未満
            else
            {
                return CurryRank.C;
            }
        }
    }
}
