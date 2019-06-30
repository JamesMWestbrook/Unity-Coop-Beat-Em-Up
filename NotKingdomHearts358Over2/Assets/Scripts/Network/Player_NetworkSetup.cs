using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_NetworkSetup :NetworkBehaviour
{
    [SerializeField] private GameObject PlayerCamera;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GameObject playerCamera = Instantiate(PlayerCamera) as GameObject;

        GetComponent<Actor>().camera = playerCamera.transform.GetChild(0);
        playerCamera.GetComponentInChildren<PlayerCamera>().player = transform;
        
    }

}
