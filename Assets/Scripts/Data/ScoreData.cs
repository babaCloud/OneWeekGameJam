using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "DataObject/ScoreData")]
public class ScoreData : ScriptableObject
{
    public int point;
    public List<string> trash;
}
