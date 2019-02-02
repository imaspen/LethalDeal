using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovementController : MonoBehaviour
{
	public float ShipSpeed;

	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(
			transform.position.x,
			transform.position.y + ShipSpeed,
			transform.position.z
		);
	}
}
