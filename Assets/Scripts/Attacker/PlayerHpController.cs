using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attacker
{
    public class PlayerHpController : HPController
    {
        protected override void Die()
        {
            GameObject.Find("/GameController").GetComponent<GameManagerController>().EndGame();
        }
    }
}
