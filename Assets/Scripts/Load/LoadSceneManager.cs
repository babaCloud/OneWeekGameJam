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

    private float fadeTime = 0.4f;

    private void Awake()
    {
        panel.enabled = true;
    }

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
        // 指定されたシーンをロードする
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
        // 自動で切り替えない
        operation.allowSceneActivation = false;

        // フェードアウトする
        Color cacheColor = panel.color;
        while (panel.color.a < 1)
        {
            cacheColor.a += Time.deltaTime / fadeTime;
            panel.color = cacheColor;

            yield return null;
        }

        // 読み込み終了まで待機
        while(operation.progress < 0.9f)
        {
            yield return null;
        }
        // ちょっと待機
        yield return new WaitForSeconds(0.2f);
        operation.allowSceneActivation = true;
    }

    // フェードイン
    IEnumerator FadeIn()
    {
        Color cacheColor = panel.color;

        // ちょっと待機
        yield return new WaitForSeconds(0.2f);

        while (panel.color.a > 0)
        {
            cacheColor.a -= Time.deltaTime / fadeTime;
            panel.color = cacheColor;

            yield return null;
        }
    }

}
