using UnityEngine;

namespace Gunner
{
    public class GunnerHpController : HPController
    {
        protected override void Die()
        {
            GameObject.Find("/GameController").GetComponent<GameManagerController>().CmdEndGame();
        }
    }
}
