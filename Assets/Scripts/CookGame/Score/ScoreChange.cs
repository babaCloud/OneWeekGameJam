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

            // �|�C���g
            private int Point = default;
            // �ő�|�C���g
            private int MaxPoint = default;
            // ��������S�~�̐�
            private int MaxTrash = default;
            // �S�~�̖��O
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
                //�X�R�A�̓z�ɑ����Ă���āI
                //  �����̖߂�lvoid����Ȃ��킷�܂�
            }

            void ReceiveItem(ItemNames guzai)
            {

            }

        }

    }
    
}
