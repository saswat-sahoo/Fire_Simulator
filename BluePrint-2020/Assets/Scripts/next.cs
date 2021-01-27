using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class next : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> fireSpawner;
    public GameObject starting;
    private GameObject startingPoint;
    public GameObject nextPoint;
    private Vector3 dierection;
    public TextMeshProUGUI Dierection;
    private float myHeading;
    private GameObject thisobject;
    
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("burn"))
        {

            fireSpawner.Add(fooObj);
        }

        InvokeRepeating("nextpoint", 3f, 1f);

       
    }
  
    private void Update()
    {

        

        if (startingPoint == null)
        {
            startingPoint = starting.GetComponent<spread>().start;
            thisobject = startingPoint;
        }
        myHeading = Vector3.Angle(new Vector3(0,0,1), dierection);
        
            //Debug.Log(Input.compass.trueHeading);

        if ( myHeading- Input.compass.trueHeading < 90f && myHeading - Input.compass.trueHeading > 0f)
        {
            Dierection.text = "DIRECTION:  North East";
        }
        if (myHeading - Input.compass.trueHeading < 180f && myHeading - Input.compass.trueHeading > 90f)
        {
            Dierection.text = "DIRECTION:  South East";
        }
        if (myHeading - Input.compass.trueHeading < 270f && myHeading - Input.compass.trueHeading > 180f)
        {
            Dierection.text = "DIRECTION:  South West";
        }
        if (myHeading - Input.compass.trueHeading < 360f && myHeading - Input.compass.trueHeading > 270f)
        {
            Dierection.text = "DIRECTION:  North West";
        }
        if (myHeading - Input.compass.trueHeading == 0f)
        {
            Dierection.text = "DIRECTION:  North ";
        }
        if (myHeading - Input.compass.trueHeading == 90f)
        {
            Dierection.text = "DIRECTION:  East ";
        }
        if (myHeading - Input.compass.trueHeading == 180f)
        {
            Dierection.text = "DIRECTION:  South ";
        }
        if (myHeading - Input.compass.trueHeading == 270f)
        {
            Dierection.text = "DIRECTION:  West ";
        }

        dierection =  (nextPoint.transform.position - startingPoint.transform.position);
       

    }


    private void nextpoint()
    {

        nextPoint = GetClosestEnemy(fireSpawner);
        thisobject = nextPoint;
    }

    private GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = startingPoint.transform.position;
        foreach (GameObject t in enemies)
        {
            if (t != null)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
              //  Debug.Log(dist);
                if (dist < minDist && dist != 0 )
                {
                    tMin = t;
                    // minDist = dist;
                    minDist = dist;
                }
               
            }
            if (t == null)
            {
                enemies.Remove(t);
                 
            }
            
        }
        

        if (Vector3.Distance(tMin.transform.position, thisobject.transform.position) <=15f && Vector3.Distance(tMin.transform.position, thisobject.transform.position)>0f)
        {
            enemies.Remove(tMin);
            Debug.Log(Vector3.Distance(tMin.transform.position, thisobject.transform.position));
            return tMin;
        }
        else
        {
            
            fireSpawner.Remove(tMin);
            return thisobject;
            //return null;
        }

    }

}
