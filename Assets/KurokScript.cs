using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KurokScript : MonoBehaviour {

    public Vector3 secondPos = Vector3.zero;
    public float Zrotation = 0;
    private bool trig = true;
    public bool ComeBack = false;
    public float ComeBackTime = 10f;

    IEnumerator ExecuteAfterTime(float time)
    {

        Vector3 temp = new Vector3();
        temp = this.transform.position;
        this.transform.position = secondPos;
        secondPos = temp;

        if (trig)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), Zrotation);
            trig = false;
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 1), -Zrotation);
            trig = true;
        }


        yield return new WaitForSeconds(time);


        temp = this.transform.position;
        this.transform.position = secondPos;
        secondPos = temp;

        if (trig)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), Zrotation);
            trig = false;
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 1), -Zrotation);
            trig = true;
        }

        Debug.Log(this.transform.position);
        
        print(100);
    }


    // Use this for initialization
    void goToSecondPoint()
    {
        

    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        


    }
}
