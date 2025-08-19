using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D�Q��
    private int speed; //�X�s�[�h�ϐ�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveUpdate(); //���E�ړ�
    }

    void MoveUpdate()
    {
        //�ړ�
        if (Input.GetKey(KeyCode.A)) //���ړ�
        {
            speed = -6; //�ړ����x
        }
        else if (Input.GetKey(KeyCode.D)) //�E�ړ�
        {
            speed = 6; //�ړ����x
        }
        else //���͖���
        {
            speed = 0; //�ړ���~
        }
    }

    //��莞�Ԃ��Ƃ�1�x�����s
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity; //�ړ����x�����ݒl����擾
        velocity.x = speed; //X�����̑��x����͂��猈��
        rb.velocity = velocity; //�v�Z�����ړ����x��Rigidbody2D�ɔ��f
    }
}