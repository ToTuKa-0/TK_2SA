using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D�Q��
    private SpriteRenderer sr; //SpriteRenderer�Q��
    public int jump; 
    bool jumping; //true(��)��folse(�n��)�����󂯕t���Ȃ�

    [HideInInspector] public float speed; //X�̈ړ����x
    [HideInInspector] public bool rightFacing; //�����Ă������(true�E false��)

    void Start()
    {
        //�Q�ƃR���|�[�l���g�擾
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rightFacing = true; // �ŏ��͉E����
    }

    void Update()
    {
        MoveUpdate(); //���E�ړ�

        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && !jumping) //�X�y�[�X�������ꂽ��+�܂��n�ʂɂ��邩
        {
            rb.AddForce(new Vector2(0, jump));
            jumping = true;
        }
    }

    void MoveUpdate()
    {
        //�ړ�
        if (Input.GetKey(KeyCode.A)) //���ړ�
        {
            speed = -6; //�ړ����x

            rightFacing = false; //�E����OFF
            sr.flipX = true; //���]��������
        }
        else if (Input.GetKey(KeyCode.D)) //�E�ړ�
        {
            speed = 6; //�ړ����x

            rightFacing = true; //�E����ON
            sr.flipX = false; //�ʏ�̌���
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Grounf�ƏՓ˂������̔���
        {
            jumping = false;
        }
    }
}