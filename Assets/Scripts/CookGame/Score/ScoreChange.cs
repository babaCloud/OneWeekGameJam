using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using sakuGame.BGM;
namespace sakuGame
{
    namespace Score
    {
        public class ScoreChange : MonoBehaviour
        {
            [Inject]
            IWhenEndBgm whenEndBgm;

            // ポイント
            private int Point = default;
            // 最大ポイント
            private int MaxPoint = default;
            // 投げられるゴミの数
            private int MaxTrash = default;
            // ゴミの名前
            private List<ItemNames> Trash;

            void Start()
            {
                whenEndBgm.EndGameEvent += FinalScoreSend;
            }

            // Update is called once per frame
            void Update()
            {

            }
            void FinalScoreSend()
            {
                //スコアの奴に送ってやって！
                //  こいつの戻り値voidじゃないわすまん
            }

            void ReceiveItem(ItemNames guzai)
            {

            }

        }

    }
    
}
