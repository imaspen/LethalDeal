using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager : UnityEngine.Networking.NetworkManager
{
    public GameObject dealerPrefab;
    public GameObject gunnerPrefab;

    public NetworkConnection DealerConnection { get; private set; }
    public NetworkConnection GunnerConnection { get; private set; }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("Hi");
        GameObject player;
        switch (NetworkServer.connections.Count)
        {
            case 1:
                player = Instantiate(gunnerPrefab);
                GunnerConnection = conn;
                break;
            case 2:
                player = Instantiate(dealerPrefab);
                DealerConnection = conn;
                break;
            default:
                return;
        }

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    public void setIP(InputField inputField)
    {
        networkAddress = inputField.text;
    }
}
