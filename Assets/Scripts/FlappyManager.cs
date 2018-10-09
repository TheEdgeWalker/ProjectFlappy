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

	private float timeSinceLastSpeedUp = 0f;
	private void FixedUpdate()
	{
	}

	private void UpdateSpeed(float speed)
	{
		skyScroller.speed = speed / 2f;
		groundScroller.speed = pipeScroller.speed = speed;
	}

	public async void Loiter(float duration)
	{
		UpdateSpeed(0f);
		await Task.Delay(TimeSpan.FromSeconds(duration));
		UpdateSpeed(speed);
	}
}
