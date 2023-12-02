using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * アイテムが一定時間で消失する処理およびプレイヤーに触れたときに速度をゼロにする処理を記述している。
 * 各処理はさほど難しいことはしていないので割愛。
 * 強いて説明するなら、36,37行目では、衝突相手オブジェクトのRigidBody コンポーネントを取得し、
 * colrb.velocity = Vector3.zeroで速度ベクトルをゼロベクトル化している。
 */


public class ItemBehavior : MonoBehaviour
{
    float birth;
    // Start is called before the first frame update
    void Start()
    {
        birth = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.fixedTime - birth > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Car1" || collision.gameObject.name == "Car2")
        {
            Destroy(gameObject);
            Rigidbody colrb = collision.gameObject.GetComponent<Rigidbody>();
            colrb.velocity = Vector3.zero;
        }
    }
}
