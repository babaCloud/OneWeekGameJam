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
    // �������邲�݂̐�
    public int MaxTrash;
    // ��ɓ��������݂̖��O
    public List<ItemNames> TrashList;
    // ���[����������
    public bool IsInRoux = false;
}
