using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyManager : MonoBehaviour
{
	public static FlappyManager instance;

	public SpriteNumber score;

	private void Awake()
	{
		instance = this;
	}
}
