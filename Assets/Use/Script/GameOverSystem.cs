using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : MonoBehaviour
{
    [Header("�Ώۂ̃^�O"),SerializeField] private string keytag = "tagTitle";
    [Header("���U���gUI�֘A")] public GameObject resultPanel; //���U���g��ʂ̐e�p�l��

    void OnEnable()
    {
        Time.timeScale = 1; //�V�[���ǂݍ��ݎ��ɃQ�[�����ĊJ
    }

    void Start()
    {
        resultPanel.SetActive(false); // ������ԂŔ�\��
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�w��^�O�ɓ����������̏���
        if (collision.gameObject.tag == keytag)
        {
            Time.timeScale = 0; //�������~�߂�
            resultPanel.SetActive(true); //���U���g��ʕ\��
        }
    }
}
