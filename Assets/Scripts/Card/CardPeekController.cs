using UnityEngine;
using UnityEngine.Networking;

namespace Card
{
	public class CardPeekController : MonoBehaviour
	{
		private Animator _animator;
		private NetworkIdentity _networkIdentity;
	
		private void Start()
		{
			_animator = GetComponent<Animator>();
			_networkIdentity = transform.parent.GetComponent<NetworkIdentity>();
		}
	
		private void OnMouseEnter()
		{
			if (!_networkIdentity.hasAuthority) return;
			_animator.SetBool("MouseOver", true);
		}

		private void OnMouseExit()
		{
			if (!_networkIdentity.hasAuthority) return;
			_animator.SetBool("MouseOver", false);
		}
	}
}
