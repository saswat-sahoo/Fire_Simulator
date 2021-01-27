using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class temp_measure : MonoBehaviour
{
   
    private float temperature=27f;
    public TextMeshProUGUI temp;
    public TextMeshProUGUI TIme;
    public GameObject issarted;
    private bool startedtemp;
    private float timesince;


    private void Start()
    {
        timesince = 0f;
    }

    private void Update()
    {
        if(!startedtemp && issarted.active == false)
        {
            InvokeRepeating("Temperature", 0f, 0.5f);
            startedtemp = true;
        }

        timesince += Time.deltaTime;

        if (startedtemp)
        {
            TIme.text = "TIME ELAPSED: " + ((int)timesince).ToString()+"sec ";
        }
        


        if (issarted.active == false)
        {
            
            if (temperature <= 1500f)
            {
                temp.text = "TEMPERATURE: " + temperature.ToString() + "C";
            }
        }
        

    }

     void Temperature()
    {
        temperature += 1f;
       
    }


}
