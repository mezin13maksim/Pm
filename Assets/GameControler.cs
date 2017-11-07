using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameControler : MonoBehaviour {

    public GameObject PmRazborkaCountainer;
    public GameObject PmSborkaCountainer;
    public GameObject AkRazborkaCountainer;
    public GameObject AkSborkaCountainer;
    private GameObject spawnedCountainer;
    public string currentAction="";
    public GameObject MenuUI;
    public GameObject TimerUI;
    public GameObject SucsesdBuildUI;
    public Text SucsesdText;
    public Text ScorePMRText;
    public Text ScorePMSText;
    public Text ScoreAKRText;
    public Text ScoreAKSText;
    public bool helper = false;


    public void setHelper()
    {
        this.helper = !helper;
    }

    public void GeneralMenuSetActive(bool active)
    {
        MenuUI.gameObject.SetActive(active);
    }

    public void TimerUISetActive(bool active)
    {
        if (active)
        {

            
            TimerUI.GetComponent<Timer>().time = 0;
            TimerUI.gameObject.SetActive(active);
            TimerUI.GetComponent<Timer>().startTick = active;

        }
        else
        {
            TimerUI.GetComponent<Timer>().startTick = active;
            TimerUI.gameObject.SetActive(active);
        }

    }

    public void SuccessfulBuildUISetActive(bool active)
    {
        if (active)
        {
            float temptime = TimerUI.GetComponent<Timer>().time;
            string temptimeString = temptime.ToString("F2");

          
            SucsesdBuildUI.SetActive(true);
            SucsesdText.text = "Норматив выполнен за " + temptimeString + " Секунд";
            TimerUISetActive(false);


            if (helper == false)
            {

                if (currentAction == "PMR")
                {
                    if (float.Parse(ScorePMRText.text) != 0)
                    {
                        if (float.Parse(ScorePMRText.text) > temptime)
                            ScorePMRText.text = temptimeString;
                    }
                    else
                        ScorePMRText.text = temptimeString;
                }
                else if (currentAction == "PMS")
                {
                    if (float.Parse(ScorePMSText.text) != 0)
                    {
                        if (float.Parse(ScorePMSText.text) > temptime)
                            ScorePMSText.text = temptimeString;
                    }
                    else
                        ScorePMSText.text = temptimeString;
                }
                else if (currentAction == "AKR")
                {
                    if (float.Parse(ScoreAKRText.text) != 0)
                    {
                        if (float.Parse(ScoreAKRText.text) > temptime && helper)
                            ScoreAKRText.text = temptimeString;
                    }
                    else
                        ScoreAKRText.text = temptimeString;

                }
                else if (currentAction == "AKS")
                {
                    if (float.Parse(ScoreAKSText.text) != 0)
                    {
                        if (float.Parse(ScoreAKSText.text) > temptime && helper)
                            ScoreAKSText.text = temptimeString;
                    }
                    else
                        ScoreAKSText.text = temptimeString;

                }
            }
            
        }
        else
        {
            OutToMenuUI();
            
        }

    }





    public void OutToMenuUI()
    {
        SucsesdBuildUI.SetActive(false);
        Destroy(spawnedCountainer);
        TimerUISetActive(false);
        GeneralMenuSetActive(true);
        currentAction = "";
    }

    public void CreatePmRazborka()
    {
        if (spawnedCountainer != null)
            Destroy(spawnedCountainer);
        spawnedCountainer = Instantiate(PmRazborkaCountainer);
        spawnedCountainer.GetComponent<PmControler>().addHelpColor = helper;
        spawnedCountainer.SetActive(true);

        GeneralMenuSetActive(false);
        TimerUISetActive(true);
        currentAction = "PMR";

    }

    public void CreatePmSborka()
    {
        if (spawnedCountainer != null)
            Destroy(spawnedCountainer);
        spawnedCountainer = Instantiate(PmSborkaCountainer);
        spawnedCountainer.GetComponent<PmControler>().addHelpColor = helper;
        spawnedCountainer.SetActive(true);

        GeneralMenuSetActive(false);
        TimerUISetActive(true);
        currentAction = "PMS";
    }

    public void CreateAkRazborka()
    {
        if (spawnedCountainer != null)
            Destroy(spawnedCountainer);
        spawnedCountainer = Instantiate(AkRazborkaCountainer);
        spawnedCountainer.GetComponent<PmControler>().addHelpColor = helper;
        spawnedCountainer.SetActive(true);

        GeneralMenuSetActive(false);
        TimerUISetActive(true);
        currentAction = "AKR";
    }

    public void CreateAkSborka()
    {
        if (spawnedCountainer != null)
            Destroy(spawnedCountainer);
        spawnedCountainer = Instantiate(AkSborkaCountainer);
        spawnedCountainer.GetComponent<PmControler>().addHelpColor = helper;
        spawnedCountainer.SetActive(true);

        GeneralMenuSetActive(false);
        TimerUISetActive(true);
        currentAction = "AKS";
    }

    public void ExitApp()
    {
        Application.Quit();
    }
    

}
