using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManagerController : MonoBehaviour
{
    private NetworkIdentity _networkIdentity;
    private UnityEngine.Networking.NetworkManager _networkManager;

    void Start()
    {
        _networkIdentity = GetComponent<NetworkIdentity>();
        _networkManager = UnityEngine.Networking.NetworkManager.singleton;
    }

    public void EndGame()
    {
#if !UNITY_EDITOR
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
