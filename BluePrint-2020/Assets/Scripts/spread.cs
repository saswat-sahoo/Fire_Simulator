using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class spread : MonoBehaviour
{
    public GameObject[] fireSpawner;
   
    public GameObject start;
    private int x;
    private bool hasStartedFire;
    public GameObject simWelcome;
    public GameObject pause;

    void Start()
    {
        fireSpawner = GameObject.FindGameObjectsWithTag("burn");
        x = Random.Range(0, fireSpawner.Length);
        simWelcome.SetActive(true);
        pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
        
        
        else
        {
            return;
        }
        
    }

    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

   

    public void quit()
    {
        Application.Quit();
    }

    public void fast()
    {
         Time.timeScale = 4f;
        
    }

    public void normal()
    {
        Time.timeScale = 1f;
    }

    public void startSim()
    {
        SpawnFire();
        fireSpawner[x].GetComponent<WildFire1>().Fire.GetComponent<ParticleSystem>().Play();
        start = fireSpawner[x];
        simWelcome.SetActive(false);
    }

    void SpawnFire()
    {
        


        fireSpawner[x].GetComponent<WildFire1>().Fire.GetComponent<ParticleSystem>().Play();
       // fireSpawner[x].GetComponent<WildFire1>().isburning = true;
      

    }
}
