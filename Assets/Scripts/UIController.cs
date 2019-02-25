using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class UIController : MonoBehaviour
{
    private NetworkIdentity _networkIdentity;

    // Use this for initialization
    protected void Start()
    {
        _networkIdentity = transform.parent.GetComponent<NetworkIdentity>();
        Init();
    }

    protected abstract void Init();

    protected virtual void Update()
    {
        if (!_networkIdentity.isLocalPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
