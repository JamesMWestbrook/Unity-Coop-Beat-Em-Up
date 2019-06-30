using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_NetworkSetup :NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        //GetComponent<NetworkAnimator>().set
    }
}
