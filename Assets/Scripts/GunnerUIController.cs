using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnerUIController : MonoBehaviour {
    private Text _timerText;
    private Timer _timer;
	// Use this for initialization
	void Start () {
        _timerText = GameObject.Find("Gunner/UI/Timer").GetComponent<Text>();
        _timer = GameObject.Find("Gunner/UI/Timer").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
        _timerText.text = _timer.countdown.ToString("0.0");
	}
}
