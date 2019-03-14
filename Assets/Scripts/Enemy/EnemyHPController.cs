using UnityEngine.Networking;

namespace Enemy
{
    public class EnemyHPController : HPController
    {
        protected override void Die()
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}