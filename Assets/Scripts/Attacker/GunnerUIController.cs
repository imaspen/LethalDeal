using UnityEngine;
using UnityEngine.UI;

namespace Attacker
{
	public class GunnerUIController : UIController {
		private Text _timerText;
		private float _timer;
	
		protected override void Init()
		{
			_timerText = GameObject.Find("UI/Timer").GetComponent<Text>();
			_timer = 60f;
		}
	
		// Update is called once per frame
		void Update () {
			_timer -= Time.deltaTime;
			_timerText.text = _timer.ToString("0.0");
		}
	}
}
