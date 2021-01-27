using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public CharacterController controller;
    public float gravity = -9.8f;
    public Vector3 velocity;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    bool isGrounded;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 30;
        }

        if (Input.GetKey(KeyCode.RightAlt))
        {
            SceneManager.LoadScene("SampleScene");
        }

        else
        {
            speed = 10;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += (transform.up * (speed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position += (transform.up * (-speed) * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            transform.position += (transform.forward * (speed) * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.position += (transform.forward * (-speed) * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.position += (transform.right * (speed) * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.position += (transform.right * (-speed) * Time.deltaTime);
        }

        if (Input.GetKey("o"))
        {
            Time.timeScale = 4f;
        }
        if (Input.GetKey("p"))
        {
            Time.timeScale = 1f;
        }



        /*float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y ;

        controller.Move(move * speed * Time.deltaTime);

      
        controller.Move(velocity * Time.deltaTime);*/
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

}
