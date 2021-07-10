using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using sakuGame.BGM;
using sakuGame.Guzai;
namespace sakuGame
{
    namespace Score
    {
        public class ScoreChange : MonoBehaviour
        {
            [Inject]
            IWhenEndBgm whenEndBgm;
            [Inject]
            IJudgeEndTime judgeEnd;

            [SerializeField]
            ScoreData scoreData;

            // ポイント
            private int score = 0;
            // 最大ポイント
            private int maxScore = 0;
            // 投げられるごみの数
            private int maxTrash = 0;
            // 鍋に入ったごみの名前
            private List<ItemNames> trashList;
            // ルーが入ったか
            private bool isInRoux = false;

            // 切れた具材のポイント
            private int pointCut = 300;
            // 切れなかった具材のポイント
            private int pointNotCut = -100;
            // 普通のごみのポイント
            private int pointNomalTrash = -300;
            // 名を冠するごみのポイント
            private int pointNamedTrash = -500;

            void Start()
            {
                whenEndBgm.EndGameEvent += FinalScoreSend;
                judgeEnd.JudgeTime += ReceiveItem;
            }

            // Update is called once per frame
            void Update()
            {

            }

            void FinalScoreSend()
            {
                // 終了時にデータを書き換える
                scoreData.ResultScore = this.score;
                scoreData.MaxScore = this.maxScore;
                scoreData.MaxTrash = this.maxTrash;
                scoreData.TrashList = this.trashList;
                scoreData.IsInRoux = this.isInRoux;
            }

            void ReceiveItem(ItemNames item,bool isSlash)
            {
                // 具材に対応したポイントを加減する

                // 具材(0～10)
                if ((int)item <= 10)
                {
                    if (isSlash)
                    {
                        score += pointCut;
                    }
                    else
                    {
                        score += pointNotCut;
                    }
                }
                // 普通のごみ(15～19)
                else if ((int)item >= 15)
                {
                    score += pointNomalTrash;
                }
                // 名を冠するごみ(20～)
                else if ((int)item >= 20)
                {
                    score += pointNamedTrash;
                    trashList.Add(item);
                }

                // ルーが入ったかどうか
                if (item == ItemNames.CurryRoux)
                {
                    isInRoux = true;
                }

                // 0以下にはしない
                if (score < 0)
                {
                    score = 0;
                }
            }

        }

    }
    
}
