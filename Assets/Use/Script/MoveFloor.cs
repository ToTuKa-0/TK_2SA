using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class MoveFloor : MonoBehaviour
{
    //���ړ��͈�
    public float MoveRangeX; //���̈ړ�
    public float MoveRangeY; //�c�̈ړ�

    public float MoveSpeed; //�ړ����x

    private Vector3 pf; //�O�t���[���Ƃ̈ʒu�̍����L�^
    private Vector3 cp; //�����̒��S�_
    private float rad = 0.0f; //���݂̊p�x��\���Ă���(���W�A��)
    private SurfaceEffector2D effector2D; //���ɑ��x��^����

    // Start is called before the first frame update
    void Start()
    {
        cp = transform.position; //�I�u�W�F�N�g�ʒu�̕ۑ�
        effector2D = GetComponent<SurfaceEffector2D>();
    }

    //0.02�b���ƂɍX�V(�ύX�\)
    void FixedUpdate()
    {
        Vector3 cl = transform.position; //������ꏊ���L��

        rad += MoveSpeed; //�p�x���X�V(�p�x���傫���Ȃ� = ��]���Ă���)

        transform.position = cp + new Vector3(MoveRangeX * Mathf.Cos(rad), MoveRangeY * Mathf.Sin(rad), 0f); //�I�u�W�F�N�g�̐V�����ʒu���~�^���Ō��߂Ă�(Cos(rad) = X�ASin(rad) = Y)

        pf = transform.position - cl;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //�w��^�O���ꏏ�ɓ�������
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.position += pf;
        }
    }
}
