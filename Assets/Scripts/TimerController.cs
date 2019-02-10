using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TimerController : NetworkBehaviour
{
    public float gameLength;

    private NetworkIdentity networkIdentity;
    private NetworkManager networkManager;

    [SyncVar]
    private float _timer;

    public float TimeRemaining {
        get { return _timer; }
        private set { _timer = value; }
    }

    // Use this for initialization
    void Start()
    {
        TimeRemaining = gameLength;
        NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();
        UnityEngine.Networking.NetworkManager networkManager = UnityEngine.Networking.NetworkManager.singleton;
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            TimeRemaining -= Time.deltaTime;
        }
        if (TimeRemaining <= 0)
        {
            if (networkIdentity.isServer && networkIdentity.isClient)
            {
                networkManager.StopHost();
            }
            else if (networkIdentity.isServer)
            {
                networkManager.StopServer();
            }
            else
            {
                networkManager.StopClient();
            }
        }
    }

    
}
