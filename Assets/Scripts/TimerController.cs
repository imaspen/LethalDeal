using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TimerController : NetworkBehaviour
{
    public float GameLength;

    [SyncVar] private float _timer;

    public float TimeRemaining
    {
        get { return _timer; }
        private set { _timer = value; }
    }

    // Use this for initialization
    void Start()
    {
        TimeRemaining = GameLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            TimeRemaining -= Time.deltaTime;
        }
        
        if (!(TimeRemaining <= 0)) return;
        GameObject.Find("/GameController").GetComponent<GameManagerController>().EndGame();
    }
}
