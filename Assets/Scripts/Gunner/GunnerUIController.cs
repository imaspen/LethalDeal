using UnityEngine;
using UnityEngine.UI;

namespace Gunner
{
	public class GunnerUIController : UIController {
		private Text _timerText;
		private TimerController _timer;
	
		protected override void Init()
		{
			_timerText = GameObject.Find("UI/Timer").GetComponent<Text>();
            _timer = GameObject.Find("GameController").GetComponent<TimerController>();
		}
	
		// Update is called once per frame
		void Update () {
            if (!isLocalPlayer) return;
			_timerText.text = _timer.TimeRemaining.ToString("0.0");
        }
	}
}
