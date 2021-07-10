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

        // ���t�����݂������Ă邩
        private bool isInGeta = false;
        private bool isInMask = false;
        private bool isInUtiwa = false;

        // �J���[�̃����N
        private CurryRank rank;
        // �t���p�̖��O���X�g
        private List<string> trashNamedList = new List<string>(4);

        void Awake()
        {

            // �f�[�^��ǂݎ��
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
                    plusNamed += "����";
                }
                else
                {
                    plusNamed += "��";
                }
            }

            return plusNamed;
        }


        // ���������郊�X�g
        void NamedCheck()
        {
            int namedTrashNum = trashList.Count;

            // ���݃��X�g���`�F�b�N����
            // �d���̂Ȃ�string�̃��X�g�����(�d����)
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

                    // 3��ޓ����Ă�̂��m�F�������_��break
                    if (isInGeta && isInMask && isInUtiwa)
                    {
                        break;
                    }
                }

                if (isInGeta)
                {
                    trashNamedList.Add("����");
                }
                if (isInMask)
                {
                    trashNamedList.Add("�}�X�N");
                }
                if (isInUtiwa)
                {
                    trashNamedList.Add("������");
                }
            }
        }

        CurryRank ScoreCheck()
        {
            // �X�R�A�]��
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
