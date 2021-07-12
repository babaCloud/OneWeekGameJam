using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableObjectPool : MonoBehaviour
{
    private List<GameObject> poolNotesList;
    private GameObject poolNotes;


    /// <summary>
    /// ListにObjectを追加する処理
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="maxCount"></param>
    public void CreatePool(GameObject obj, int maxCount)
    {
        poolNotes = obj;
        poolNotesList = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewObject();
            newObj.SetActive(false);
            poolNotesList.Add(newObj);
        }

    }
    /// <summary>
    /// ObjectPoolの使用中でないものを探して返す関数　すべて使用中だったら新たに生成して返す
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        // 使用中でないものを探して返す
        foreach (var obj in poolNotesList)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        // 全て使用中だったら新しく作って返す
        var newObj = CreateNewObject();
        newObj.SetActive(true);
        poolNotesList.Add(newObj);
        return newObj;
    }

    /// <summary>
    /// ListからObjectをInstanceする処理
    /// </summary>
    /// <returns></returns>
    private GameObject CreateNewObject()
    {
        var newObj = Instantiate(poolNotes);
        newObj.name = poolNotes.name + (poolNotesList.Count + 1);
        return newObj;
    }
}
