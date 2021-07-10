using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sakuGame;

namespace Result
{
    public enum CurryRank
    {
        S,  // �p�[�t�F�N�g
        A,
        B,
        C,
        O,  // ������
        G   // ����
    }

    public class ResultScoreCalc : MonoBehaviour
    {
        [SerializeField]
        ScoreData scoreData;

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

        // ���O�����݂̃t���O 2�i��
        // 001����, 010�}�X�N, 100������
        private byte trashFlag0b = 0;
        // �J���[�̃����N
        private CurryRank rank;
        // �t���p�̖��O���X�g
        private List<string> namedTrashList = new List<string>(4);

        void Awake()
        {
            // �f�[�^��ǂݎ��
            this.score = scoreData.ResultScore;
            this.maxScore = scoreData.MaxScore;
            this.inTrash = scoreData.InTrash;
            this.maxTrash = scoreData.MaxTrash;
            this.trashList = scoreData.TrashList;
            this.isInRoux = scoreData.IsInRoux;

            // �X�R�A��]������
            rank = ScoreCheck();
            NamedCheck();
        }

        // ���݂̃t���O��Ԃ�
        public byte GetTrashFlag()
        {
            return trashFlag0b;
        }

        // �����N��Ԃ�
        public CurryRank GetCurryRank()
        {
            return rank;
        }

        // �u�Z�Z�ƁZ�Z����v�̌`�̕������Ԃ�
        public string GetTrashNameText()
        {
            int namedNum = namedTrashList.Count;

            string plusNamed = "";

            for (int i = 0; i < namedNum; i++)
            {
                plusNamed += namedTrashList[i];
                if (i == namedNum - 1)
                {
                    plusNamed += "����";
                }
                else
                {
                    plusNamed += "��";
                }
            }

            return plusNamed;
        }

        // ���݃��X�g���`�F�b�N����
        // �d���̂Ȃ�string�̃��X�g�����(�d����)
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
                    namedTrashList.Add("����");
                }
                if ((trashFlag0b & 0b010) == 0b010)
                {
                    namedTrashList.Add("�}�X�N");
                }
                if ((trashFlag0b & 0b100) == 0b100)
                {
                    namedTrashList.Add("������");
                }
            }
        }

        // �X�R�A�]��
        CurryRank ScoreCheck()
        {
            // �p�[�t�F�N�g!!
            if (score == maxScore)
            {
                return CurryRank.S;
            }
            // ���������ĂȂ�(��؂����݂����[��)
            else if (score == 0 && inTrash == 0 && !isInRoux)
            {
                return CurryRank.O;
            }
            // ���݂΂���(�X�R�A���}�C�i�X)
            else if (score < 0)
            {
                return CurryRank.G;
            }
            // 3/4�ȏ� ���� �S�~�������ĂȂ�
            else if (score >= maxScore * 0.75f && inTrash == 0)
            {
                return CurryRank.A;
            }
            // 2/4�ȏ�
            else if (score >= maxScore * 0.5f)
            {
                return CurryRank.B;
            }
            // 2/4����
            else
            {
                return CurryRank.C;
            }
        }
    }
}
