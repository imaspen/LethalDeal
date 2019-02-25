using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class UIController : NetworkBehaviour {

	// Use this for initialization
	protected virtual void Start ()
	{
		if (!isLocalPlayer) GameObject.Find("UI").SetActive(false);
		else Init();
	}

	protected abstract void Init();
}
