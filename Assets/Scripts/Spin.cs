using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 投擲アイテムが回転するためだけのスクリプト。
 * 投擲アイテムは移動するEmptyの親オブジェクトと回転する実態を持つ子オブジェクトから構成されている。
 * 回転と前進を両立するためにこのような構造となっている。
 * GetChildを使用しないためだけに作られたｶｯｽｶｽのスクリプト。
 */

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 10f);
    }
}
