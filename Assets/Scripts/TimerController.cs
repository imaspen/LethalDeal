using UnityEngine;
using UnityEngine.Networking;

public class TimerController : NetworkBehaviour
{
    [SyncVar] private float _timer;
    public float GameLength;

    public float TimeRemaining
    {
        get { return _timer; }
        private set { _timer = value; }
    }

    // Use this for initialization
    private void Start()
    {
        TimeRemaining = GameLength;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isServer) TimeRemaining -= Time.deltaTime;

        if (!(TimeRemaining <= 0)) return;
        GameObject.Find("/GameController").GetComponent<GameManagerController>().CmdEndGame();
    }
}
