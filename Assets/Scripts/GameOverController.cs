using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) SceneManager.LoadScene("Main Menu");
	}
}
