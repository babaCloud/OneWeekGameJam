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

            // スコアのデータファイル
            [SerializeField]
            ScoreData scoreData;
            // シーンロード君
            [SerializeField]
            LoadSceneManager loadScene;

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
                scoreData.InTrash = this.inTrash;
                scoreData.MaxTrash = this.maxTrash;
                scoreData.TrashList = this.trashList;
                scoreData.IsInRoux = this.isInRoux;

                // シーンをロードする
                loadScene.LoadScene("Result");
            }

            void ReceiveItem(ItemNames _item,bool _isSlash)
            {
                // 具材に対応したポイントを加減する

                // 具材(0～10)
                if ((int)_item <= 10)
                {
                    // 切れてる
                    if (_isSlash)
                    {
                        score += pointCut;
                    }
                    // 切れてない
                    else
                    {
                        score += pointNotCut;
                    }

                    // ルーが入ったか
                    if (!isInRoux && _item == ItemNames.CurryRoux)
                    {
                        isInRoux = true;
                    }
                }
                // ごみ(15～)
                else if ((int)_item >= 15)
                {
                    // 名を冠するごみ(20～)
                    if ((int)_item >= 20)
                    {
                        score += pointNamedTrash;
                        // リストに追加する
                        trashList.Add(_item);
                    }
                    // 普通のごみ
                    else
                    {
                        score += pointNomalTrash;
                    }

                    // ごみが入った数を数える
                    inTrash++;
                }

            }

        }

    }
    
}
