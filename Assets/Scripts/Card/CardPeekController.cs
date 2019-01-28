using UnityEngine;

namespace Card
{
	public class CardPeekController : MonoBehaviour
	{
		private Animator _animator;
	
		private void Start()
		{
			_animator = GetComponentInChildren<Animator>();
		}
	
		private void OnMouseEnter()
		{
			_animator.SetBool("MouseOver", true);
		}

		private void OnMouseExit()
		{
			_animator.SetBool("MouseOver", false);
		}
	}
}
