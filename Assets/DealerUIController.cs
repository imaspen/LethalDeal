using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealerUIController : MonoBehaviour {

    private Text _hpCounter;

	// Use this for initialization
	void Start () {
        _hpCounter = GameObject.Find("Dealer/UI/Player HP").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        _hpCounter.text = "29";
	}
}
