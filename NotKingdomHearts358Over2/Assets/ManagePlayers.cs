using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ManagePlayers : NetworkBehaviour
{

    public List<GameObject> getPlayers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [Server]
    void Update()
    {
        
    }

    
}
