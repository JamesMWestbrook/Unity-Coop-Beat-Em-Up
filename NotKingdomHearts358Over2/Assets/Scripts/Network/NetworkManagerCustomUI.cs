using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class NetworkManagerCustomUI : MonoBehaviour
{

    [SerializeField] private NetworkManager manager;
    [SerializeField] private InputField networkAddress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manager.networkAddress = networkAddress.text;
    }
}
