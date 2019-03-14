using UnityEngine;
using UnityEngine.UI;

namespace Gunner
{
    public class GunnerUIController : UIController
    {
        private HPController _hp;
        private Text _hpText;
        private TimerController _timer;
        private Text _timerText;

        protected override void Init()
        {
            _timerText = GameObject.Find("Gunner(Clone)/UI/Timer").GetComponent<Text>();
            _hpText = GameObject.Find("Gunner(Clone)/UI/Attacker Health").GetComponent<Text>();
            _timer = GameObject.Find("GameController").GetComponent<TimerController>();
            _hp = transform.parent.GetComponent<HPController>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            _timerText.text = "Time Remaining: " + _timer.TimeRemaining.ToString("0.0");
            _hpText.text = "HP: " + _hp.HP;
        }
    }
}