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
            // Start is called before the first frame update
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

        }

    }

}
