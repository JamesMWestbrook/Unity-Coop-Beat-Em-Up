using System;
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

       
        controls.Player.MoveCamera.performed += ctx => m_Look = ctx.ReadValue<Vector2>();
        controls.Player.MoveCamera.cancelled += ctx => m_Look = Vector2.zero;

        controls.Player.MoveCamera.Enable();


        //controls.

    }

    


    private Vector2 m_Move;
    private Vector2 m_Look;
    private Vector2 m_Rotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null)
        {
            Destroy(cameraPivot.gameObject);
        }

        cameraPivot.position = player.position;
         mouseX = Input.GetAxis("Mouse X");
         mouseY = Input.GetAxis("Mouse Y");
        
        cameraPivot.Rotate(0, -m_Look.x * Time.deltaTime * CameraSpeed * 2, 0);

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
