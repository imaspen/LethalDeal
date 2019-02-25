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
		
		[Command]
		public void CmdSpawnCard(string cardName, Vector3 position)
		{
			var newCard = Instantiate(CardPrefab);
			newCard.transform.position = position;
			newCard.GetComponent<CardData>().LoadJson(cardName);
			NetworkServer.SpawnWithClientAuthority(newCard, GameObject.Find("/Network Manager").GetComponent<NetworkManager>().DealerConnection);
		}

		[Command]
		public void CmdSpawnEnemy(string enemyPath)
		{
			var enemy = Instantiate(EnemyPrefab);
			JsonUtility.FromJsonOverwrite(Resources.Load<TextAsset>("Enemies/" + enemyPath).text,
				enemy.GetComponent<ProjectileEmitter>());
			NetworkServer.Spawn(enemy);
		}
	}
}
