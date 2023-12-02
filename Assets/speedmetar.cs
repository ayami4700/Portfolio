using System.Collections;
//使わなかったので一応コメントアウト。
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//クラス名を"PowerMeterRadial"にするとコルーチン名と衝突してエラーが出るので何か別の奴で。
//UIManager的な物を作っていたら、それに追記したら良い。
public class PowerMeterRadialTest : MonoBehaviour
{

	//イメージをインスペクターから紐付け。
	[SerializeField]
	Image powerMeterImage;

	//パワーメーターのスピードの倍率。
	float powerMeterSpeedRate = 1.0f;

	//パワーメーターを止めた時の値。
	//0～1までの間の値が入るので、使用する時はMathf.Lerp(powerMin, powerMax, powerMeterValue)みたいな感じで。
	float powerMeterValue = 0;

	//パワーメーターコルーチンの経過時間。
	float powerMeterElapsedTime;

	//コルーチンの管理用。
	Coroutine powerMeter;


	//円形のパワーメーターを開始したい時に呼ぶ。
	void StartPowerMeterRadial()
	{
		powerMeter = StartCoroutine("PowerMeterRadial");
	}


	//円形
	IEnumerator PowerMeterRadial()
	{
		powerMeterElapsedTime = 0;

		while (true)
		{
			powerMeterElapsedTime += Time.deltaTime * powerMeterSpeedRate;

			//最後まで行くと往復ループVer。
			powerMeterImage.fillAmount = Mathf.PingPong(powerMeterElapsedTime, 1.0f);
			//最後まで行くと最初からループVer。
			//			powerMeterImage.fillAmount = powerMeterElapsedTime % 1.0f;

			//画面をタップすると停止してパワーを確定。
			if (Input.GetMouseButtonDown(0))
			{
				powerMeterValue = powerMeterImage.fillAmount;
				yield break;
			}

			yield return null;
		}
	}

}
