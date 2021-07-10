using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableObjectPool : MonoBehaviour
{
    private List<GameObject> poolNotesList;
    private GameObject poolNotes;


    /// <summary>
    /// List��Object��ǉ����鏈��
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
    /// ObjectPool�̎g�p���łȂ����̂�T���ĕԂ��֐��@���ׂĎg�p����������V���ɐ������ĕԂ�
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        // �g�p���łȂ����̂�T���ĕԂ�
        foreach (var obj in poolNotesList)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        // �S�Ďg�p����������V��������ĕԂ�
        var newObj = CreateNewObject();
        newObj.SetActive(true);
        poolNotesList.Add(newObj);
        return newObj;
    }

    /// <summary>
    /// List����Object��Instance���鏈��
    /// </summary>
    /// <returns></returns>
    private GameObject CreateNewObject()
    {
        var newObj = Instantiate(poolNotes);
        newObj.name = poolNotes.name + (poolNotesList.Count + 1);
        return newObj;
    }
}
