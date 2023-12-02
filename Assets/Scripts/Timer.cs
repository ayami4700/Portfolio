using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ゲーム開始時のカウントダウンと経過時間の表示を行うスクリプト。
 * コルーチン部分を見ればわかると思うが、一秒ごとにカウントダウンするコルーチンをStart関数に組み込んでいる。
 * カウントダウンが終わったところで、カウントダウン用のテキストを非アクティブ化し、経過時間表示用のテキストをアクティブ化している。
 * Update部分においては、経過時間をいい感じの見た目で表示する処理を行っている。
 * 懸念としては
 * 経過時間表示処理でキャストやら小数点以下の丸めなどが行われている点（これは追加手順に回せばいい気もする）。
 */

public class Timer : MonoBehaviour
{
    public Text DisplayText;
    public Text P1CountText;
    public Text P2CountText;

    public string DisplayTime; //表示する経過時間の文字列
    float keikajikan; //経過時間を表す英単語、なじみなさすぎてワロタ
    int min;
    int sec;
    int ssec;
    
    // Start is called before the first frame update
    void Start()
    {
        //経過時間表示用のテキストを非表示にする（カウントダウン終了後に表示される）。
        //カウントダウン用のコルーチンの呼び出し。
        DisplayText.gameObject.SetActive(false);
        StartCoroutine(countDown());
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが開始してからの経過時間からカウントダウン分の3秒を引いている。
        //min,sec,ssecにそれぞれ何分経過したか、何秒経過したか、コンマ何秒経過したかを格納している（コンマ何秒の部分って呼び名とかないのだろうか）
        keikajikan = Time.fixedTime - 3f;
        min = (int)keikajikan / 60;
        sec = (int)(keikajikan - min * 60);
        ssec = (int)((keikajikan % 1) * 100);

        //上に並んだ時間を格納している変数を表示桁数を制御して表示。
        DisplayTime = min.ToString() + ":" + sec.ToString("d2") + ":" + ssec.ToString("d2");
        DisplayText.text = DisplayTime;
    }
    IEnumerator countDown()
    {
        //3秒分のカウントダウンを行い、スタートの表示。
        for(int i = 0; i < 3; i++)
        {
            P1CountText.text = (3 - i).ToString();
            P2CountText.text = (3 - i).ToString();
            yield return new WaitForSeconds(1f);
        }
        P1CountText.text = "START!!";
        P2CountText.text = "START!!";
        yield return new WaitForSeconds(0.5f);

        //それ以降使わないのでカウントダウン用のテキスト非表示化し経過時間表示用のテキストを表示。
        //改造か追加手順でこれらの非表示にしたテキストをゴールインの表示に使ってもよいかもしれない。
        P1CountText.gameObject.SetActive(false);
        P2CountText.gameObject.SetActive(false);
        DisplayText.gameObject.SetActive(true);
    }
}
