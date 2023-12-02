using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelesController : MonoBehaviour
{

    public Rigidbody carBody;

	public List<AxelInfo> axleInfos; // 個々の車軸の情報
	public float maxMotorTorque; // ホイールの最大モータートルク
	public float maxSteeringAngle; // ホイールのハンドル最大角度
    public float maxBrakeTorque; //ホイールの最大ブレーキトルク

    public List<string> axisName;
    public KeyCode BrakeKey;

	// Use this for initialization
	void Start()
	{
        carBody = GetComponent<Rigidbody>();
        Invoke("Init", 3f);
	}

    // Update is called once per frame
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    public void FixedUpdate()
	{
        float motor = maxMotorTorque * Input.GetAxis(axisName[0]);
		float steering = maxSteeringAngle * Input.GetAxis(axisName[1]);
        bool brake = Input.GetKey(BrakeKey);
        
		foreach (AxelInfo axleInfo in axleInfos)
		{
            if (brake)
            {
                axleInfo.leftWheel.brakeTorque = maxBrakeTorque;
                axleInfo.rightWheel.brakeTorque = maxBrakeTorque;
            }
            else
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
            }

			if (axleInfo.steering)
			{
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}
			if (axleInfo.motor)
			{
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);

        }
	}

    public void Init()
    {
        maxMotorTorque = 1000;
        maxSteeringAngle = 30;
        maxBrakeTorque = 600;
    }

}

[System.Serializable]
public class AxelInfo
{
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor; // このホイールはモーターにアタッチされているかどうか
	public bool steering; // このホイールはハンドルの角度を反映しているかどうか
    
}