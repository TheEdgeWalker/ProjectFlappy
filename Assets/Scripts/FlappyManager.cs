using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FlappyManager : MonoBehaviour
{
	public static FlappyManager instance;

	public SpriteNumber score;

	public BackgroundScroller skyScroller;
	public BackgroundScroller groundScroller;
	public PipeScroller pipeScroller;

	private float speed = 2f;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		UpdateSpeed(speed);
	}

	private void FixedUpdate()
	{
	}

	private void UpdateSpeed(float newSpeed)
	{
		skyScroller.speed = newSpeed / 2f;
		groundScroller.speed = pipeScroller.speed = newSpeed;
	}

	public async void Brake(float duration)
	{
		UpdateSpeed(0f);
		await Task.Delay(TimeSpan.FromSeconds(duration));
		UpdateSpeed(speed);
	}
}
