using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyManager : MonoBehaviour
{
	public static FlappyManager instance;

	public SpriteNumber score;

	public BackgroundScroller skyScroller;
	public BackgroundScroller groundScroller;
	public PipeScroller pipeScroller;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
	}

	private float timeSinceLastSpeedUp = 0f;
	private void FixedUpdate()
	{
	}
}
