using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D参照
    private int speed; //スピード変数

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveUpdate(); //左右移動
    }

    void MoveUpdate()
    {
        //移動
        if (Input.GetKey(KeyCode.A)) //左移動
        {
            speed = -6; //移動速度
        }
        else if (Input.GetKey(KeyCode.D)) //右移動
        {
            speed = 6; //移動速度
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
}