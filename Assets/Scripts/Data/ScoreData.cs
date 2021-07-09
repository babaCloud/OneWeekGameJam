using System.Collections.Generic;
using UnityEngine;
using sakuGame.Guzai;

[CreateAssetMenu(fileName = "ScoreData", menuName = "DataObject/ScoreData")]
public class ScoreData : ScriptableObject
{
    public int point;
    public List<string> trash;
}
