using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    // シーンごとのパネルを入れる
    [SerializeField]
    public Image panel;

    private float fadeTime = 0.45f;

    // ロードされたらフェードインする
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    // ロードしたいシーンの名前を渡す
    public void LoadScene(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }

    // フェードアウトしてから指定されたシーンをロードする
    IEnumerator FadeOut(string _sceneName)
    {
        Color cacheColor = panel.color;

        while (panel.color.a < 1)
        {
            cacheColor.a += Time.deltaTime / fadeTime;
            panel.color = cacheColor;

            yield return null;
        }

        Debug.Log("シーン読み込み");
        SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
    }

    // フェードイン
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
