using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    private readonly string _gameScene = "Game Screen";
    private readonly string _deckbuilderScene = "Deckbuilder";
    private readonly string _optionsScene = "Options Menu";

    public void onPlayClick()
    {
        SceneManager.LoadScene(_gameScene);
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
