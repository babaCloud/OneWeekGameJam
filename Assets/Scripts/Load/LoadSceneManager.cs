using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    // �V�[�����Ƃ̃p�l��������
    [SerializeField]
    public Image panel;

    private float fadeTime = 0.45f;

    // ���[�h���ꂽ��t�F�[�h�C������
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    // ���[�h�������V�[���̖��O��n��
    public void LoadScene(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }

    // �t�F�[�h�A�E�g���Ă���w�肳�ꂽ�V�[�������[�h����
    IEnumerator FadeOut(string _sceneName)
    {
        Color cacheColor = panel.color;

        while (panel.color.a < 1)
        {
            cacheColor.a += Time.deltaTime / fadeTime;
            panel.color = cacheColor;

            yield return null;
        }

        Debug.Log("�V�[���ǂݍ���");
        SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
    }

    // �t�F�[�h�C��
    IEnumerator FadeIn()
    {
        Color cacheColor = panel.color;

        while (panel.color.a > 0)
        {
            cacheColor.a -= Time.deltaTime / fadeTime;
            panel.color = cacheColor;

            yield return null;
        }
    }

}
