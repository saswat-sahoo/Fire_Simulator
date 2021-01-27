using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wildfire : MonoBehaviour
{
    public List <GameObject> fireSpawner;
    
    public GameObject Fire;
    public bool nearbyIsBurning;
    private Wildfire wild;
    public bool isburning;
    public GameObject indicator;
    private bool done;
    private bool ok;
    private bool maybe;
    private bool ohh;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("burn")) {

            fireSpawner.Add(fooObj);
        }
        nearbyIsBurning = false;
        indicator.SetActive(false);
    }

   private GameObject GetClosestEnemy(List <GameObject> enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist && dist!=0 && dist<=3f)
            {
                tMin = t;
                minDist = dist;
            }
        }
        
        enemies.Remove(tMin);
      
        return tMin;
       
    }


    // Update is called once per frame
    void Update()
    {
        if (isburning )
        {
            GameObject closestTree = GetClosestEnemy(fireSpawner);
            
            // Debug.Log(closestTree.name);
            //closestTree.GetComponent<Wildfire>().indicator.SetActive(true);
            if (!maybe || !ohh)
            {
                if (maybe)
                {
                    ohh = true;
                }
                wild = closestTree.GetComponent<Wildfire>();
                wild.nearbyIsBurning = true;
                maybe = true;
            }
           
            if (!done)
            {
                StartCoroutine(SpawnFire());
                done = true;
            }
            
        }

        if(isburning && nearbyIsBurning)
        {
            if (!ok)
            {
                StartCoroutine(SpawnFire());
            }
            ok = true;
               
            
        }

       if(nearbyIsBurning && !isburning)
        {
            StartCoroutine(SpawnFire());
            
        }

      
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
    }
    IEnumerator SpawnFire()
    {



        
        yield return new WaitForSeconds(3f);
        Fire.GetComponent<ParticleSystem>().Play();
        isburning = true;

    }
    
}
