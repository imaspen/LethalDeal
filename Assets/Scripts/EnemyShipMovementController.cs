using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyShipMovementController : NetworkBehaviour
{
	private NetworkIdentity _networkIdentity;
	
	public float ShipSpeed;

	private void Start()
	{
		_networkIdentity = GetComponent<NetworkIdentity>();
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, ShipSpeed);
	}

//	private void Update ()
//	{
//		if (!_networkIdentity.isServer) return;
//		transform.position = new Vector3(
//			transform.position.x,
//			transform.position.y + ShipSpeed,
//			transform.position.z
//		);
//	}
}
