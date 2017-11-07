using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmControler : MonoBehaviour {


    private int stage = 0;
    public List<GameObject> Details;
    public GameObject gameController;
    public bool addHelpColor = false;
    public Color helpColor = Color.red;

    public void nextDetail(GameObject g)
    {
        stage++;
        if (stage <= Details.Count - 1)
        {
            
            Details[stage - 1].GetComponent<TransformationScript>().isActive = false;
            Details[stage].GetComponent<TransformationScript>().isActive = true;

            if (addHelpColor)
            {
                Details[stage - 1].GetComponent<SpriteRenderer>().color = Color.white;
                Details[stage].GetComponent<SpriteRenderer>().color = helpColor;
            }
        }
        if (stage == Details.Count)
        {
            Details[stage - 1].GetComponent<TransformationScript>().isActive = false;
            gameController.GetComponent<GameControler>().SuccessfulBuildUISetActive(true);
            if (addHelpColor)
            {
                Details[stage - 1].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
    }
    
    void Start () {
        if (Details.Count != 1 || Details.Count != 0)
        {
            Details[0].GetComponent<TransformationScript>().isActive = true;
            if (addHelpColor) { Details[0].GetComponent<SpriteRenderer>().color = helpColor; }
            for (int i = 1; i <= Details.Count - 1; i++)
            {
                Details[i].GetComponent<TransformationScript>().isActive = false;

            }

        }
    }
	
	

}
