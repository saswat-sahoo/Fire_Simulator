using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildFire1 : MonoBehaviour
{
   
    public GameObject isme;
    public GameObject Fire;
    private bool isburning;
    public GameObject burningTree;
    private void Start()
    {
        isme = GameObject.FindGameObjectWithTag("manager");
        burningTree.SetActive(false);
    }
    private void Update()
    {
        
        if (this.gameObject == isme.GetComponent<next>().nextPoint && !isburning)
        {
            StartCoroutine(SpawnFire());
            isburning = true;
            burningTree.SetActive(true);
        }

        

    }

    IEnumerator SpawnFire()
    {
        yield return new WaitForSeconds(2f);
        Fire.GetComponent<ParticleSystem>().Play();
        isburning = true;

    }

}
