using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Button menuButton;

    private void Start()
    {
        menuButton.onClick.AddListener(Menu);
    }

    private void Menu()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Main Menu");
    }
}
