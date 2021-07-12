using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Result
{
    public class ShowResult : MonoBehaviour
    {
        // �J���[�̖��O�Ƃ��摜�̃f�[�^
        // enum CurryRank�Ɠ�������
        [SerializeField]
        CurryData[] currys;

        // �X�R�A�]���̃X�N���v�g
        ResultScoreCalc resScoCal;

        private int rank = 0;
        private string namedTrashText;
        private string curryName;
        private Sprite currySprite;

        // ���݂�\�����邽�߂̃t���O
        private byte trashFlag0b;
        private bool getaActive = false;
        private bool maskActive = false;
        private bool utiwaActive = false;


        // ���݂̖��O��\������text�R���|�[�l���g
        [Header("Text"), SerializeField]
        Text trashTextComp;
        // �J���[�̖��O��\������V
        [SerializeField]
        Text curryTextComp;

        // �J���[�̉摜��\������image�R���|�[�l���g
        [Header("Image"), SerializeField]
        Image curryImageComp;
        // �w�i�̌�
        [SerializeField]
        Image flashImageComp;
        // ����3��image�R���|�[�l���g
        [SerializeField]
        Image GetaImageComp, MaskImageComp, UtiwaImageComp;

        void Start()
        {
            resScoCal = GetComponent<ResultScoreCalc>();

            // �]�����擾����
            rank = (int)resScoCal.GetCurryRank();
            // ���݂̕�������擾����
            namedTrashText = resScoCal.GetTrashNameText();
            // �t���O���擾����
            trashFlag0b = resScoCal.GetTrashFlag();
            ImportFlags();

            // �J���[�̖��O�Ɖ摜��ǂݍ���
            curryName = currys[rank].curryName;
            currySprite = currys[rank].image;

            // UI�ɔ��f����
            trashTextComp.text = namedTrashText;
            curryTextComp.text = curryName;
            curryImageComp.sprite = currySprite;
            // ���݂̕\��
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

        // 2�i���̃t���O��P�̂�bool�ɒ���
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
