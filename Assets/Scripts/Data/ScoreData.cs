using System.Collections.Generic;
using UnityEngine;
using sakuGame.Guzai;
using sakuGame;

[CreateAssetMenu(fileName = "ScoreData", menuName = "DataObject/ScoreData")]
public class ScoreData : ScriptableObject
{
    // ポイント
    public int ResultScore;
    // 最大ポイント
    public int MaxScore;
    // 入ったごみの数
    public int InTrash = 0;
    // 投げられるごみの数
    public int MaxTrash;
    // 鍋に入ったごみのリスト
    public List<ItemNames> TrashList;
    // ルーが入ったか
    public bool IsInRoux = false;
}
