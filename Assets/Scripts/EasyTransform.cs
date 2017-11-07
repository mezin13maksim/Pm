using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTransform : MonoBehaviour {

    public bool isActive = false;
    public Vector3 secondPos = Vector3.zero;
    public float Zrotation= 0;
    public bool OnPistol =true;
    public bool ComeBack = false;
    public float ComeBackTime = 10f;


    IEnumerator ExecuteAfterTime(float time)
    {

        Vector3 temp = new Vector3();
        temp = this.transform.position;
        this.transform.position = secondPos;
        secondPos = temp;

        if (OnPistol)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), Zrotation);
            OnPistol = false;
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 1), -Zrotation);
            OnPistol = true;
        }


        yield return new WaitForSeconds(time);


        temp = this.transform.position;
        this.transform.position = secondPos;
        secondPos = temp;

        if (OnPistol)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), Zrotation);
            OnPistol = false;
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 1), -Zrotation);
            OnPistol = true;
        }

        
    }


    void goToSecondPoint()
    {
        
        Vector3 temp = new Vector3();
        temp = this.transform.localPosition;
        this.transform.localPosition = secondPos;
        secondPos = temp;

        if (OnPistol)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), Zrotation);
            OnPistol = false;
            transform.SendMessageUpwards("setgo");
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 1), -Zrotation);
            OnPistol = true;
            transform.SendMessageUpwards("setgo");
        }

        

    }


    

    void OnMouseDown()
    {
        if (isActive)
        {
            if (ComeBack)
                StartCoroutine(ExecuteAfterTime(ComeBackTime));
            else
                goToSecondPoint();
        }
    }


}
