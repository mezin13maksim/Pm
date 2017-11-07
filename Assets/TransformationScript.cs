using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationScript : MonoBehaviour {

    public bool isActive = false;
    public List<Vector3> Positions;
    private bool rt = false;
    public bool isRotation = false;
    public bool comeback = false;
    public float rotationAngle = 0;
    public float comebackTime = 0.5f;


    private Vector3 getAndRemoveFirst()
    {
        if (Positions.Count != 0)
        {
            Vector3 temp = new Vector3();
            temp = Positions[0];
            Positions.RemoveAt(0);
            return temp;
        }
        else
            return Vector3.zero;
    }

    private void rotate()
    {
        
        if (rt == false && Positions.Count==1)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), rotationAngle);
            rt = true;
        }
        else if (rt == true && Positions.Count == 1)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), -rotationAngle);
            rt = false;
        }

    }

    public void goToNextPoint()
    {
        
        if (Positions.Count != 0)
        {
            Vector3 temp = new Vector3();
            temp = this.transform.localPosition;
            this.transform.localPosition = getAndRemoveFirst();
            Positions.Add(temp);
        }

       
        if (isRotation == true)
            rotate();
        

    }


    public void OnMouseDown()
    {
        if (isActive)
        {
            if (comeback == false)
            {
                goToNextPoint();
                SendMessageUpwards("nextDetail", this.gameObject);
            }
            else
            {
                StartCoroutine(comebackTransform(comebackTime));
                SendMessageUpwards("nextDetail", this.gameObject);
            }
        }
    }

    IEnumerator comebackTransform(float time)
    {

        goToNextPoint();

        yield return new WaitForSeconds(time);

        goToNextPoint();
       
    }


}
