using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D参照
    private SpriteRenderer sr; //SpriteRenderer参照
    public int jump; 
    bool jumping; //true(空中)かfolse(地面)しか受け付けない

    [HideInInspector] public float speed; //Xの移動速度
    [HideInInspector] public bool rightFacing; //向いている方向(true右 false左)

    void Start()
    {
        //参照コンポーネント取得
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rightFacing = true; // 最初は右向き
    }

    void Update()
    {
        MoveUpdate(); //左右移動

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !jumping) //スペースを押されたか+まだ地面にいるか
        {
            rb.AddForce(new Vector2(0, jump));
            jumping = true;
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
}