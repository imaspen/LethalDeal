using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private float _cooldown;
    private NetworkManager _networkManager;

    public float Cooldown;
    public Text ExitGameMessage;

    private void Start()
    {
        _networkManager = GameObject.Find("/Network Manager").GetComponent<NetworkManager>();
        _networkManager.offlineScene = "";
        _cooldown = Cooldown;
    }

    private void Update()
    {
        if (_cooldown > 0 || !Input.anyKeyDown)
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown < 0) ExitGameMessage.text = "Press any key to return to the main menu.";
            return;
        }

        _networkManager.StopClient();
        _networkManager.StopServer();
        SceneManager.LoadScene("Main Menu");
    }
}
