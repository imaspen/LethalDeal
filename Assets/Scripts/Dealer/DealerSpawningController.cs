using System;
using Card;
using Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace Dealer
{
    public class DealerSpawningController : NetworkBehaviour
    {
        public GameObject CardPrefab;
        public GameObject EnemyPrefab;
        public GameObject EnemyProjectilePrefab;

        [Command]
        public void CmdSpawnCard(string cardName, Vector3 position)
        {
            var newCard = Instantiate(CardPrefab);
            newCard.transform.position = position;
            newCard.GetComponent<CardData>().LoadJson(cardName);
            NetworkServer.SpawnWithClientAuthority(newCard, GameObject.Find("/Network Manager").GetComponent<NetworkManager>().DealerConnection);
        }

        [Command]
        public void CmdSpawnEnemy(string enemyPath, string emitterType, float pos)
        {
            var enemy = Instantiate(EnemyPrefab);
            ProjectileEmitter emitter;
            switch (emitterType)
            {
                case "SpreadShot": emitter = enemy.AddComponent<SpreadShotProjectileEmitter>(); break;
                case "DelayedRotating": emitter = enemy.AddComponent<DelayedRotatingProjectileEmitter>(); break;
                default: throw new Exception("Emitter Type Not Found");
            }
            JsonUtility.FromJsonOverwrite(Resources.Load<TextAsset>("Enemies/" + enemyPath).text, emitter);
            emitter.ProjectilePrefab = EnemyProjectilePrefab;
            var position = enemy.transform.position;
            position = new Vector3(1.5f * (3 - pos), position.y, position.z);
            enemy.transform.position = position;
            NetworkServer.Spawn(enemy);
        }

        [Command]
        public void CmdDestroyCard(GameObject go)
        {
            NetworkServer.Destroy(go);
        }
    }
}
