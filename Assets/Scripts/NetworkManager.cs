using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : UnityEngine.Networking.NetworkManager {

    public GameObject dealerPrefab;
    public GameObject gunnerPrefab;

    private GameObject _dealer;
    private GameObject _gunner;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
        GameObject player;
        if (_gunner == null) player = _gunner = Instantiate(gunnerPrefab);
        else if (_dealer == null) player = _dealer = Instantiate(dealerPrefab);
        else return;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
