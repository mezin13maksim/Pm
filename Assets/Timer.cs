using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public bool startTick = false;
    public Text timeText;

    void FixedUpdate()
    {

        if (startTick)
        {
            if (time >= 0)
            {
                time += Time.fixedDeltaTime;

                timeText.text = time.ToString("F2");
            }
        }
    }

    void Start()
    {



    }
}
