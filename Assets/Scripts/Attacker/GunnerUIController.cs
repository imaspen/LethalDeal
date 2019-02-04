using UnityEngine;
using UnityEngine.UI;

namespace Attacker
{
	public class GunnerUIController : UIController {
		private Text _timerText;
		private float _timer;
        public GameObject gameOverPanel;

        protected override void Init()
		{
			_timerText = GameObject.Find("UI/Timer").GetComponent<Text>();
			_timer = 5f;
            gameOverPanel = GameObject.Find("UI/GameOverPanel");
      
            gameOverPanel.SetActive(false);

        }
	
		// Update is called once per frame
		void Update () {
			_timer -= Time.deltaTime;
			_timerText.text = _timer.ToString("0.0");
            
            if (_timer <= 0.0)
            {
                GameOver();
            }
		}

        void GameOver()
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
	}
}
