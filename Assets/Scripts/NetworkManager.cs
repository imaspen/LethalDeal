using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : UnityEngine.Networking.NetworkManager {

    public GameObject dealerPrefab;
    public GameObject gunnerPrefab;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("Hi");
        GameObject player;
        switch (NetworkServer.connections.Count)
        {
            case 1:
                player = Instantiate(gunnerPrefab);
                break;
            case 2:
                player = Instantiate(dealerPrefab);
                break;
            default:
                return;
        }
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
