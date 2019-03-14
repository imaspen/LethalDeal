using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManagerController : NetworkBehaviour
{
    private NetworkIdentity _networkIdentity;
    private NetworkManager _networkManager;

    private void Start()
    {
        _networkIdentity = GetComponent<NetworkIdentity>();
        _networkManager = GameObject.Find("/Network Manager").GetComponent<NetworkManager>();
    }

    [Command]
    public void CmdEndGame()
    {
        TargetWin(_networkManager.DealerConnection);
        TargetLose(_networkManager.GunnerConnection);
    }

    [TargetRpc]
    private void TargetWin(NetworkConnection connection)
    {
        SceneManager.LoadScene("Game Over");
    }

    [TargetRpc]
    private void TargetLose(NetworkConnection connection)
    {
        SceneManager.LoadScene("Game Over");
    }
}
