using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
public class InputTester : MonoBehaviour
{

    [SerializeField] private UnityTutorial controls;
    private void OnEnable()
    {
        controls.Ship.fire.performed += HandleFire;
        controls.Ship.fire.Enable();
    }
    private void OnDisable()
    {
        controls.Ship.fire.performed -= HandleFire;
        controls.Ship.fire.Disable();
    }

    private void HandleFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
