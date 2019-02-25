using UnityEngine;
using UnityEngine.UI;

namespace Dealer
{
	public class DealerUIController : UIController {

		private Text _hpCounter;
		private Text _timerText;
		private TimerController _timer;

		protected override void Init()
		{
			_hpCounter = GameObject.Find("UI/Player HP").GetComponent<Text>();
			_timerText = GameObject.Find("UI/Timer").GetComponent<Text>();
			_timer = GameObject.Find("/GameController").GetComponent<TimerController>();
		}
	
		// Update is called once per frame
		void Update() {
			if (!isLocalPlayer) return;
			_timerText.text = _timer.TimeRemaining.ToString("0.0");
		}
	}
}
