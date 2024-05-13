using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class RemoveNetworkHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject NetMgr = GameObject.Find("NetworkManager");
        NetworkManagerHUD NetMgrHUD = NetMgr.GetComponent<NetworkManagerHUD>();
        NetMgrHUD.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
