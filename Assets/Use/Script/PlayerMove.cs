using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D参照
    private SpriteRenderer sr; //SpriteRenderer参照

    private int jump_f = 1; //ジャンプの初速
    private float jump_m = 0.5f; //ボタンを押せる長さ
    private int jump_p = 5; //ジャンプ中に加わる力
    bool jumping; //true(空中)かfolse(地面)しか受け付けない
    private float jump_t; //残りジャンプ可能時間

    [HideInInspector] public float speed; //Xの移動速度
    [HideInInspector] public bool rightFacing; //向いている方向(true右 false左)

    void Start()
    {
        //参照コンポーネント取得
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2Dを取得
        sr = GetComponent<SpriteRenderer>(); //SpriteRendererを取得

        rightFacing = true; // 最初は右向き
    }

    void Update()
    {
        MoveUpdate(); //左右移動

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //スペースを押されたか+まだ地面にいるか
        {
            jumping = true; //ジャンプ中のフラグ
            jump_t = jump_m; //経過時間リセット
            rb.velocity = new Vector2(rb.velocity.x, jump_f); //上方向にジャンプの初速を加える
        }

        //ボタンを押している間に追加の力を加える
        if (Input.GetKey(KeyCode.Space) && jumping)
        {
            if (jump_t > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump_p); //ジャンプ中に時間が残っている場合は力が加算される
                jump_t -= Time.deltaTime; //ジャンプ可能時間を減らす
            }
            else
            {
                jumping = false; //時間経過で終了
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
        }
    }

    void MoveUpdate()
    {
        //移動
        if (Input.GetKey(KeyCode.A)) //左移動
        {
            speed = -6; //移動速度

            rightFacing = false; //右向きOFF
            sr.flipX = true; //反転した向き
        }
        else if (Input.GetKey(KeyCode.D)) //右移動
        {
            speed = 6; //移動速度

            rightFacing = true; //右向きON
            sr.flipX = false; //通常の向き
        }
        else //入力無し
        {
            speed = 0; //移動停止
        }
    }

    //一定時間ごとに1度ずつ実行
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity; //移動速度を現在値から取得
        velocity.x = speed; //X方向の速度を入力から決定
        rb.velocity = velocity; //計算した移動速度をRigidbody2Dに反映
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Grounfと衝突した時の判定
        {
            jumping = false;
        }
    }

    bool IsGrounded() //地面にいるかどうか判定
    {
        return Mathf.Abs(rb.velocity.y) < 0.01f; //y方向の速度がほぼゼロなら地面にいるとみなす
    }
}