using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    public string TitleName; //シーンの名を入れる

    public void LoadScene()
    {
        SceneManager.LoadScene(TitleName); //該当シーンをロード
    }
}
