using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * プレイヤーの時速を表示するスクリプト。
 * Velocity,Magnitudeについて。
 * VelocityはRigidBodyの速度ベクトルを取得するメソッド。
 * Magnitudeはベクトルの大きさを取得するメソッド。つまり速度ベクトルを速度の大きさに変換している。
 * 生徒に説明するときは、
 * XZ方向に対して角度をつけて進んでいる状況を例示して、各方向の速度を考えられることを示唆。
 * Velocityではこの各方向への速度を取得できると説明し、
 * Magnitudeが元の進行方向への速度の大きさを取得していると説明するのがよいのかな。
 * 生徒の理解力によっては速度の大きさを取得できる呪文でもいいかも。
 * 個人的にはベクトルの大きさの取得ってノルムじゃねと思ったりもする。
 */
public class SpeedMeter : MonoBehaviour
{
    public Text SpeedText;
    public Rigidbody CarRb;
    // Start is called before the first frame update
    void Start()
    {
        CarRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SpeedText.text = "Speed: " + (CarRb.velocity.magnitude*3.6f).ToString("f2") + "km/h";
    }
}
