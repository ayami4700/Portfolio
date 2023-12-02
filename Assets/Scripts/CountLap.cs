using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountLap : MonoBehaviour
{
    public List<bool> posFlag;
    public Timer timecs;
    public int lap;

    public List<Text> Lap;

    public Text goaltext;

    // Start is called before the first frame update
    void Start()
    {
        lap = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Col0")
        {
            if (posFlag[0] && posFlag[1] && posFlag[2] && lap < 4)
            {
                Lap[lap - 1].text += " " + timecs.DisplayTime;
                lap++;
            }
            posFlag[0] = true;
            posFlag[1] = false;
            posFlag[2] = false;

            if (posFlag[0] && posFlag[1] && posFlag[2] && lap > 4)
            {
                goaltext.text = "GOAL!!!";
                //ゲームを止めるってどうやるの
            }
        }
        if (other.gameObject.name == "Col1")
        {
            posFlag[1] = true;
            posFlag[2] = false;
        }
        if (other.gameObject.name == "Col2")
        {
            posFlag[2] = true;
        }

    }
}
