using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D�Q��
    private SpriteRenderer sr; //SpriteRenderer�Q��

    private int jump_f = 1; //�W�����v�̏���
    private float jump_m = 0.5f; //�{�^���������钷��
    private int jump_p = 5; //�W�����v���ɉ�����
    bool jumping; //true(��)��folse(�n��)�����󂯕t���Ȃ�
    private float jump_t; //�c��W�����v�\����

    [HideInInspector] public float speed; //X�̈ړ����x
    [HideInInspector] public bool rightFacing; //�����Ă������(true�E false��)

    void Start()
    {
        //�Q�ƃR���|�[�l���g�擾
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2D���擾
        sr = GetComponent<SpriteRenderer>(); //SpriteRenderer���擾

        rightFacing = true; // �ŏ��͉E����
    }

    void Update()
    {
        MoveUpdate(); //���E�ړ�

        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //�X�y�[�X�������ꂽ��+�܂��n�ʂɂ��邩
        {
            jumping = true; //�W�����v���̃t���O
            jump_t = jump_m; //�o�ߎ��ԃ��Z�b�g
            rb.velocity = new Vector2(rb.velocity.x, jump_f); //������ɃW�����v�̏�����������
        }

        //�{�^���������Ă���Ԃɒǉ��̗͂�������
        if (Input.GetKey(KeyCode.Space) && jumping)
        {
            if (jump_t > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump_p); //�W�����v���Ɏ��Ԃ��c���Ă���ꍇ�͗͂����Z�����
                jump_t -= Time.deltaTime; //�W�����v�\���Ԃ����炷
            }
            else
            {
                jumping = false; //���Ԍo�߂ŏI��
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
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

    bool IsGrounded() //�n�ʂɂ��邩�ǂ�������
    {
        return Mathf.Abs(rb.velocity.y) < 0.01f; //y�����̑��x���قڃ[���Ȃ�n�ʂɂ���Ƃ݂Ȃ�
    }
}