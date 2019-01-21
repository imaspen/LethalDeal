using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    private readonly string _deckbuilderScene = "Deckbuilder";
    private readonly string _optionsScene = "Options Menu";
    private NetworkManager _networkManager;

    public void Start()
    {
        _networkManager = GameObject.Find("/Network Manager").GetComponent<NetworkManager>();
        Debug.Log(_networkManager);
    }

    public void onPlayAsGunnerClick()
    {
        _networkManager.StartHost();
    }

    public void onPlayAsDealerClick()
    {
        _networkManager.StartClient();
    }

    public void onDeckbuilderClick()
    {
        SceneManager.LoadScene(_deckbuilderScene);
    }

    public void onOptionsClick()
    {
        SceneManager.LoadScene(_optionsScene);
    }

    public void onQuitClicked()
    {
        Application.Quit();
    }
}
