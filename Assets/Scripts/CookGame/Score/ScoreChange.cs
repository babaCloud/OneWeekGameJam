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

            // �|�C���g
            private int score = 0;
            // �ő�|�C���g
            private int maxScore = 0;
            // �������邲�݂̐�
            private int maxTrash = 0;
            // ��ɓ��������݂̖��O
            private List<ItemNames> trashList;
            // ���[����������
            private bool isInRoux = false;

            // �؂ꂽ��ނ̃|�C���g
            private int pointCut = 300;
            // �؂�Ȃ�������ނ̃|�C���g
            private int pointNotCut = -100;
            // ���ʂ̂��݂̃|�C���g
            private int pointNomalTrash = -300;
            // ���������邲�݂̃|�C���g
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
                // �I�����Ƀf�[�^������������
                scoreData.ResultScore = this.score;
                scoreData.MaxScore = this.maxScore;
                scoreData.MaxTrash = this.maxTrash;
                scoreData.TrashList = this.trashList;
                scoreData.IsInRoux = this.isInRoux;
            }

            void ReceiveItem(ItemNames item,bool isSlash)
            {
                // ��ނɑΉ������|�C���g����������

                // ���(0�`10)
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
                // ���ʂ̂���(15�`19)
                else if ((int)item >= 15)
                {
                    score += pointNomalTrash;
                }
                // ���������邲��(20�`)
                else if ((int)item >= 20)
                {
                    score += pointNamedTrash;
                    trashList.Add(item);
                }

                // ���[�����������ǂ���
                if (item == ItemNames.CurryRoux)
                {
                    isInRoux = true;
                }

                // 0�ȉ��ɂ͂��Ȃ�
                if (score < 0)
                {
                    score = 0;
                }
            }

        }

    }
    
}
