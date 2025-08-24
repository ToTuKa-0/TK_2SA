using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : MonoBehaviour
{
    [Header("対象のタグ"),SerializeField] private string keytag = "tagTitle";
    [Header("リザルトUI関連")] public GameObject resultPanel; //リザルト画面の親パネル

    void OnEnable()
    {
        Time.timeScale = 1; //シーン読み込み時にゲームを再開
    }

    void Start()
    {
        resultPanel.SetActive(false); // 初期状態で非表示
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //指定タグに当たった時の処理
        if (collision.gameObject.tag == keytag)
        {
            Time.timeScale = 0; //動きを止める
            resultPanel.SetActive(true); //リザルト画面表示
        }
    }
}
