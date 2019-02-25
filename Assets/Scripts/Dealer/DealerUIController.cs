using UnityEngine;
using UnityEngine.UI;

namespace Dealer
{
    public class DealerUIController : UIController
    {
        private Text _hpCounter;
        private Text _timerText;
        private TimerController _timer;
        private HPController _hp;

        protected override void Init()
        {
            _hpCounter = GameObject.Find("Dealer(Clone)/UI/Player HP").GetComponent<Text>();
            _timerText = GameObject.Find("Dealer(Clone)/UI/Timer").GetComponent<Text>();
            _timer = GameObject.Find("/GameController").GetComponent<TimerController>();
            _hp = GameObject.Find("/Gunner(Clone)").GetComponent<HPController>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            _timerText.text = "Time Remaining: " + _timer.TimeRemaining.ToString("0.0");
            _hpCounter.text = "Enemy HP: " + _hp.HP;
        }
    }
}
