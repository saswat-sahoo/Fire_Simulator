using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public Transform player;
    float Xrotation = 0f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
        Xrotation -= mousey;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
    }
}
