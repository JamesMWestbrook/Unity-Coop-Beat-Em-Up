using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform cameraPivot;
    public Transform player;
    public float CameraSpeed = 4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPivot.position = player.position;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        cameraPivot.Rotate(-mouseY * Time.deltaTime * CameraSpeed, -mouseX * Time.deltaTime * CameraSpeed, 0);

        Vector3 euler = cameraPivot.localEulerAngles;
        euler.x =Mathf.Clamp(Mathf.Repeat(cameraPivot.eulerAngles.x + 180, 360),0, 360) - 180;
        cameraPivot.localEulerAngles = euler;
    }
}
