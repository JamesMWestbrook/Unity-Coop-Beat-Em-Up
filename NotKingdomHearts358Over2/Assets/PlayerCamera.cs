using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] private Transform PivotCamera;
    [SerializeField] private Transform Player;
    public float CameraSpeed = 4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PivotCamera.position = Player.position;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        PivotCamera.Rotate(-mouseY * Time.deltaTime * CameraSpeed, -mouseX * Time.deltaTime * CameraSpeed, 0);


        Vector3 euler = PivotCamera.localEulerAngles;
        euler.x =Mathf.Clamp(Mathf.Repeat(PivotCamera.eulerAngles.x + 180, 360),0, 360) - 180;
        PivotCamera.localEulerAngles = euler;
    }
}
