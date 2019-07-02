using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class AutoMatchStart : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NetworkManager>().StartHost();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
