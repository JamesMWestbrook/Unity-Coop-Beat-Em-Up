using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
public class MoveTest : MonoBehaviour
{

    [SerializeField] private NewControls controls;
    private void OnEnable()
    {
        controls.Player.shoot.performed += Handleshoot;
        controls.Player.shoot.Enable();
    }
    private void OnDisable()
    {
        controls.Player.shoot.performed -= Handleshoot;
        controls.Player.shoot.Disable();
    }

    private void Handleshoot(InputAction.CallbackContext context)
    {
        Debug.Log("shoot");
    }
}
