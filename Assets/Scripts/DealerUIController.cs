using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealerUIController : UIController {

    private Text _hpCounter;

	protected override void Init()
	{
        _hpCounter = GameObject.Find("UI/Player HP").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update() {
        _hpCounter.text = "29";
	}
}
