using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    public string TitleName; //�V�[���̖�������

    public void LoadScene()
    {
        SceneManager.LoadScene(TitleName); //�Y���V�[�������[�h
    }
}
