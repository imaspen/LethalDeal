using UnityEngine;
using UnityEngine.UI;

namespace Gunner
{
	public class GunnerUIController : UIController {
		private Text _timerText;
		private Text _hpText;
		private TimerController _timer;
		private HPController _hp;
	
		protected override void Init()
		{
			_timerText = GameObject.Find("UI/Timer").GetComponent<Text>();
			_hpText = GameObject.Find("UI/Attacker Health").GetComponent<Text>();
            _timer = GameObject.Find("GameController").GetComponent<TimerController>();
			_hp = transform.parent.GetComponent<HPController>();
		}
		
		// Update is called once per frame
		protected override void Update () {
			base.Update();
			_timerText.text = _timer.TimeRemaining.ToString("0.0");
			_hpText.text = "HP: " +_hp.HP;
		}
	}
}
