using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	private Animator _animator;
	private Collider2D _collider;
	private SpriteRenderer _rederer;
	public float healthRestoration = 1;

	private void Awake()
	{
		_rederer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) {
			_rederer.enabled = false;
			_animator.SetTrigger("Received");
			collision.SendMessageUpwards("AddHealth", healthRestoration);
			_collider.enabled = false;

			Destroy(gameObject, 2f);
		}
	}
}
