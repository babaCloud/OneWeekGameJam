using System.Collections.Generic;
using UnityEngine;
using sakuGame.Guzai;
using sakuGame;

[CreateAssetMenu(fileName = "ScoreData", menuName = "DataObject/ScoreData")]
public class ScoreData : ScriptableObject
{
    // �|�C���g
    public int ResultScore;
    // �ő�|�C���g
    public int MaxScore;
    // ���������݂̐�
    public int InTrash = 0;
    // �������邲�݂̐�
    public int MaxTrash;
    // ��ɓ��������݂̃��X�g
    public List<ItemNames> TrashList;
    // ���[����������
    public bool IsInRoux = false;
}
