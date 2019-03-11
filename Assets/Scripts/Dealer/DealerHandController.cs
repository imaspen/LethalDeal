using Card;
using Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace Dealer
{
	public class DealerHandController : MonoBehaviour
	{
		public float Cooldown { get; set; }

		private DealerSpawningController _spawningController;
		private DeckController _deckController;

		private void Start()
		{
			if (!transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer) return;
			_spawningController = transform.parent.gameObject.GetComponent<DealerSpawningController>();
			_deckController = transform.parent.GetComponentInChildren<DeckController>();
			for (var i = 0; i < 5; i++)
			{
				AddCardToHand(i);
			}
		}

		private void Update ()
		{
			if (Cooldown <= 0) return;
			Cooldown -= Time.deltaTime;
		}

		public void PlayCard(CardData cardData, float zPos)
		{
			if (Cooldown > 0) return;
			_spawningController.CmdSpawnEnemy(cardData.Spawns, cardData.Emitter, zPos);
			_spawningController.CmdDestroyCard(cardData.gameObject);
			_deckController.AddCard(cardData.Title);
			Cooldown = 2f;
			AddCardToHand(Mathf.FloorToInt(5 - zPos));
		}

		public void AddCardToHand(int position)
		{
			var cardPos = new Vector3(position * 1.5f - 3, -4, 5 - position);
			_spawningController.CmdSpawnCard(_deckController.GetNextCard(), cardPos);
		}
	}
}
