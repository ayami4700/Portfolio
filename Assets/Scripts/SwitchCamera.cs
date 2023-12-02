using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject FrontCamera;
    public GameObject BackCamera;
    public List<KeyCode> cameraSwitch; 
    // Start is called before the first frame update
    void Start()
    {
        MainCamera.SetActive(true);
        FrontCamera.SetActive(false);
        BackCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(cameraSwitch[0]))
        {
            MainCamera.SetActive(true);
            FrontCamera.SetActive(false);
            BackCamera.SetActive(false);
        }
        if (Input.GetKey(cameraSwitch[1]))
        {
            MainCamera.SetActive(false);
            FrontCamera.SetActive(true);
            BackCamera.SetActive(false);
        }
        if (Input.GetKey(cameraSwitch[2]))
        {
            MainCamera.SetActive(false);
            FrontCamera.SetActive(false);
            BackCamera.SetActive(true);
        }
    }
}
