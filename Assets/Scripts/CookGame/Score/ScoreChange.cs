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

            // �X�R�A�̃f�[�^�t�@�C��
            [SerializeField]
            ScoreData scoreData;
            // �V�[�����[�h�N
            [SerializeField]
            LoadSceneManager loadScene;

            // �|�C���g
            private int score = 0;
            // �ő�|�C���g
            private int maxScore = 0;
            // ���������݂̐�
            private int inTrash = 0;
            // �������邲�݂̐�
            private int maxTrash = 0;
            // ��ɓ��������݂̃��X�g
            private List<ItemNames> trashList = new List<ItemNames>(16);
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
                scoreData.InTrash = this.inTrash;
                scoreData.MaxTrash = this.maxTrash;
                scoreData.TrashList = this.trashList;
                scoreData.IsInRoux = this.isInRoux;

                // �V�[�������[�h����
                loadScene.LoadScene("Result");
            }

            void ReceiveItem(ItemNames _item,bool _isSlash)
            {
                // ��ނɑΉ������|�C���g����������

                // ���(0�`10)
                if ((int)_item <= 10)
                {
                    // �؂�Ă�
                    if (_isSlash)
                    {
                        score += pointCut;
                    }
                    // �؂�ĂȂ�
                    else
                    {
                        score += pointNotCut;
                    }

                    // ���[����������
                    if (!isInRoux && _item == ItemNames.CurryRoux)
                    {
                        isInRoux = true;
                    }
                }
                // ����(15�`)
                else if ((int)_item >= 15)
                {
                    // ���������邲��(20�`)
                    if ((int)_item >= 20)
                    {
                        score += pointNamedTrash;
                        // ���X�g�ɒǉ�����
                        trashList.Add(_item);
                    }
                    // ���ʂ̂���
                    else
                    {
                        score += pointNomalTrash;
                    }

                    // ���݂����������𐔂���
                    inTrash++;
                }

            }

        }

    }
    
}
