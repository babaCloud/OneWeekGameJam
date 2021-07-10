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

        // 名前つきごみのフラグ 2進数
        // 001下駄, 010マスク, 100うちわ
        private byte trashFlag0b = 0;
        // カレーのランク
        private CurryRank rank;
        // 付加用の名前リスト
        private List<string> namedTrashList = new List<string>(4);

        void Awake()
        {
            // データを読み取る
            this.score = scoreData.ResultScore;
            this.maxScore = scoreData.MaxScore;
            this.inTrash = scoreData.InTrash;
            this.maxTrash = scoreData.MaxTrash;
            this.trashList = scoreData.TrashList;
            this.isInRoux = scoreData.IsInRoux;

            // スコアを評価する
            rank = ScoreCheck();
            NamedCheck();
        }

        // ごみのフラグを返す
        public byte GetTrashFlag()
        {
            return trashFlag0b;
        }

        // ランクを返す
        public CurryRank GetCurryRank()
        {
            return rank;
        }

        // 「〇〇と〇〇入り」の形の文字列を返す
        public string GetTrashNameText()
        {
            int namedNum = namedTrashList.Count;

            string plusNamed = "";

            for (int i = 0; i < namedNum; i++)
            {
                plusNamed += namedTrashList[i];
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

        // ごみリストをチェックして
        // 重複のないstringのリストを作る(重そう)
        void NamedCheck()
        {
            int namedTrashNum = trashList.Count;

            if (namedTrashNum != 0)
            {
                for (int i = 0; i < namedTrashNum; i++)
                {
                    switch (trashList[i])
                    {
                        case ItemNames.Geta:
                            trashFlag0b |= 0b001;
                            break;
                        case ItemNames.Mask:
                            trashFlag0b |= 0b010;
                            break;
                        case ItemNames.Utiwa:
                            trashFlag0b |= 0b100;
                            break;
                    }

                    if (trashFlag0b == 0b111)
                    {
                        break;
                    }
                }

                if ((trashFlag0b & 0b001) == 0b001)
                {
                    namedTrashList.Add("下駄");
                }
                if ((trashFlag0b & 0b010) == 0b010)
                {
                    namedTrashList.Add("マスク");
                }
                if ((trashFlag0b & 0b100) == 0b100)
                {
                    namedTrashList.Add("うちわ");
                }
            }
        }

        // スコア評価
        CurryRank ScoreCheck()
        {
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
