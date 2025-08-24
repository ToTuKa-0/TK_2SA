using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    public string TitleName; //ƒV[ƒ“‚Ì–¼‚ğ“ü‚ê‚é

    public void LoadScene()
    {
        SceneManager.LoadScene(TitleName);
    }
}
