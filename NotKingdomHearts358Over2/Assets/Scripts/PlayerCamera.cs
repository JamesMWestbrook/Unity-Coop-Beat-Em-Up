using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class PlayerCamera : MonoBehaviour
{

    public Transform cameraPivot;
    public Transform player;
    public float CameraSpeed = 4;
   [SerializeField] private NewControls controls;
    float mouseX;
    float mouseY;

    private void Awake()
    {
    }

    public void OnEnable()
    {
        controls.Player.shoot.performed += _ => Shoot();
        controls.Player.shoot.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPivot.position = player.position;
         mouseX = Input.GetAxis("Mouse X");
         mouseY = Input.GetAxis("Mouse Y");

        

        //cameraPivot.Rotate(-mouseY * Time.deltaTime * CameraSpeed, -mouseX * Time.deltaTime * CameraSpeed, 0);
        cameraPivot.Rotate(-mouseY * Time.deltaTime * CameraSpeed, -mouseX * Time.deltaTime * CameraSpeed, 0);

        Vector3 euler = cameraPivot.localEulerAngles;
        euler.x =Mathf.Clamp(Mathf.Repeat(cameraPivot.eulerAngles.x + 180, 360),0, 360) - 180;
        cameraPivot.localEulerAngles = euler;
    }

    public void Shoot()
    {
        Debug.Log("Space works");
    }

    

    private void OnDisable()
    {
        
    }

}
