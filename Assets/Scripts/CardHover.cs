using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHover : MonoBehaviour
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
