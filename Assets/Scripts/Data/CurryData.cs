using UnityEngine;

namespace Result
{
    [CreateAssetMenu(fileName = "CurryData", menuName = "DataObject/CurryData")]
    public class CurryData : ScriptableObject
    {
        public CurryRank rank;
        public string curryName;
        public Sprite image;
    }
}