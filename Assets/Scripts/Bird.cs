﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public float thrust = 5f;

	private Animator animator;
	private Rigidbody2D physicsBody;

	private void Start()
	{
		animator = GetComponent<Animator>();
		physicsBody = GetComponent<Rigidbody2D>();
	}

	bool isFlapping = false;
	private void FixedUpdate()
	{
		if (!isFlapping && Input.GetButtonDown("Flap"))
		{
			animator.SetTrigger("Flap");
			isFlapping = true;
			physicsBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
		}

		if (Input.GetButtonDown("Special"))
		{
			FlappyManager.instance.Loiter(2f);
		}
	}

	public void AnimationEvent(string name)
	{
		if (name == "FlapEnd")
		{
			isFlapping = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Pipe")
		{
			gameObject.SetActive(false);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ScoringArea")
		{
			FlappyManager.instance.score.value += 5;
		}
	}
}
