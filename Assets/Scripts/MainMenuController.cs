using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject ConnectionDisplay;
    
    private NetworkManager _networkManager;

    public void Start()
    {
        _networkManager = GameObject.Find("/Network Manager").GetComponent<NetworkManager>();
        Debug.Log(_networkManager);
    }

    public void OnPlayAsGunnerClick()
    {
        _networkManager.StartHost();
    }

    public void OnPlayAsDealerClick()
    {
        ConnectionDisplay.SetActive(true);
    }

    public void OnConnectClick()
    {
        _networkManager.StartClient();
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
