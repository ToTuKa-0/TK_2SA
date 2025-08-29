using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class MoveFloor : MonoBehaviour
{
    //床移動範囲
    public float MoveRangeX; //横の移動
    public float MoveRangeY; //縦の移動

    public float MoveSpeed; //移動速度

    private Vector3 pf; //前フレームとの位置の差を記録
    private Vector3 cp; //動きの中心点
    private float rad = 0.0f; //現在の角度を表している(ラジアン)
    private SurfaceEffector2D effector2D; //床に速度を与える

    // Start is called before the first frame update
    void Start()
    {
        cp = transform.position; //オブジェクト位置の保存
        effector2D = GetComponent<SurfaceEffector2D>();
    }

    //0.02秒ごとに更新(変更可能)
    void FixedUpdate()
    {
        Vector3 cl = transform.position; //今いる場所を記憶

        rad += MoveSpeed; //角度を更新(角度が大きくなる = 回転している)

        transform.position = cp + new Vector3(MoveRangeX * Mathf.Cos(rad), MoveRangeY * Mathf.Sin(rad), 0f); //オブジェクトの新しい位置を円運動で決めてる(Cos(rad) = X、Sin(rad) = Y)

        pf = transform.position - cl;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //指定タグも一緒に動く条件
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.position += pf;
        }
    }
}
