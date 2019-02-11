using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TimerController : NetworkBehaviour
{
    public float GameLength;

    private NetworkIdentity _networkIdentity;
    private UnityEngine.Networking.NetworkManager _networkManager;

    [SyncVar] private float _timer;

    public float TimeRemaining
    {
        get { return _timer; }
        private set { _timer = value; }
    }

    // Use this for initialization
    void Start()
    {
        TimeRemaining = GameLength;
        _networkIdentity = GetComponent<NetworkIdentity>();
        _networkManager = UnityEngine.Networking.NetworkManager.singleton;
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            TimeRemaining -= Time.deltaTime;
        }

#if !UNITY_EDITOR
        Debug.Log("ayo");
        if (!(TimeRemaining <= 0)) return;
        _networkManager.offlineScene = "Game Over";
        if (_networkIdentity.isServer && _networkIdentity.isClient)
        {
            _networkManager.StopHost();
        }
        else if (_networkIdentity.isServer)
        {
            _networkManager.StopServer();
        }
        else
        {
            _networkManager.StopClient();
        }
#endif
    }
}
