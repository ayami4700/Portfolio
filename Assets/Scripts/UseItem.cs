using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * アイテムの取得及び使用にかかる処理を行うスクリプト。
 * 所持アイテムを表示する仕組みを説明する。
 * 現在所持しているアイテムを示すための見せるだけのモデルをCarの子オブジェクトとして用意しておき、
 * 基本状態をSetActive Falseとしておく。（これらのモデルのオブジェクトはItemModelListとして管理する）
 * アイテムボックスに触れたときにランダムな番号を取得し、該当するインデックスのアイテムのモデルをアクティブに、他のモデルを非アクティブにする。
 * こうすることで、取得したアイテムのみが表示され、他のアイテムは表示されない。
 * 
 * アイテム使用キーを押した際の処理について説明する。
 * アイテムボックスに触れたときに得られたランダムな数字のインデックスに該当するモデルを非アクティブ化し、アイテムを消費したことを表現する。
 * SwitchCaseの分岐で使用したアイテムの効果を実行する。それぞれのアイテムの効果は該当箇所で詳述する。
 */



public class UseItem : MonoBehaviour
{
    public int r;
    public Rigidbody car;
    public List<GameObject> ItemModelList;
    public GameObject sm;
    public GameObject obstacle;
    public KeyCode UseItemKey;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();   //加速アイテムでAddForceするためにGetComponent
        r =0;                              //現在所持しているアイテムの種類を示す変数。初期値としてダミーアイテムに該当する値を入れている。
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(UseItemKey))
        {
            ItemModelList[r].SetActive(false);    //アイテム消費にかかる非表示処理
            switch (r)
            {
                case 1:         //投擲アイテム。アイテムのプレハブ自身が推進、回転の動きのスクリプトを持っているのでインスタンス化するだけ。
                    Instantiate(sm, transform.position + new Vector3(0f, 0.5f, 0f) + 5f*transform.forward, transform.rotation);
                    r = 0;
                    break;
                case 2:         //加速アイテム。前方にAddForceすることで加速を表現。
                    car.AddForce(transform.forward * 1000000);   
                    r = 0;
                    break;
                case 3:         //障害物アイテム。触れた相手の速度をゼロにするスクリプトがはいっているのでインスタンス化するだけ。
                    Instantiate(obstacle, transform.position + new Vector3(0f, 0.5f, 0f) + -3f * transform.forward, transform.rotation);
                    r = 0;
                    break;
            }
            
        }//各ケースにおいて、r=0としているのは、アイテムを使用した後にどのアイテムも所持していない状態にするため。
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ItemBox")
        {
            //Destroy(other.gameObject);
            StartCoroutine(disappear(other.gameObject));            //触れたアイテムボックスを一時的に非アクティブかする処理。引数ありコルーチンとなっているため知識懸念。

            //以下の乱数で出てくるアイテムが決定する。その後のFor文の処理によって取得したアイテムをアクティブ化し他のアイテムを非アクティブ化している
            //（アイテム使用時に使用したアイテムのモデルは非アクティブ化されるので多分ItemModelList[r].SetActive(true);だけでもよい
            //なんらかの不具合で非アクティブ化されなかった場合を考えて他のアイテムの非アクティブ化も行っている）

            r = Random.Range(1, 4);
            for (int i = 0; i < ItemModelList.Count; i++){
                if (i == r)
                {
                    ItemModelList[i].SetActive(true);
                }
                else
                {
                    ItemModelList[i].SetActive(false);
                }
            }
            
        }
    }

    //触れたアイテムボックスを一時的に非アクティブ化する処理。コルーチンの知識を見ればわかる。
    IEnumerator disappear(GameObject col)
    {
        col.SetActive(false);
        yield return new WaitForSeconds(5f);
        col.SetActive(true);
    }
}
