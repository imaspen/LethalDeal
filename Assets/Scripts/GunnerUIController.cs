using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnerUIController : MonoBehaviour {
    private Text _timerText;
    private float _timer;
	// Use this for initialization
	void Start () {
        _timerText = GameObject.Find("UI/Timer").GetComponent<Text>();
		_timer = 60f;
	}
	
	// Update is called once per frame
	void Update () {
		_timer -= Time.deltaTime;
		_timerText.text = _timer.ToString("0.0");
	}
}
