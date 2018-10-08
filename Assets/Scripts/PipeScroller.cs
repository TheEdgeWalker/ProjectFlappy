using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScroller : MonoBehaviour
{
	public GameObject prefabPipe;

	public float speed = 2f;
	public float interval = 2f;
	public float yVariance = 1.5f;

	private const int count = 16;
	private List<GameObject> pipes = new List<GameObject>(count);
	private int frontIndex = 0;

	void Start()
	{
		for (int i = 0; i < count; ++i)
		{
			GameObject newPipe = Instantiate(prefabPipe, transform);
			newPipe.transform.position = new Vector3(10f + i * interval, Random.Range(-yVariance, yVariance));
			pipes.Add(newPipe);
		}
	}

	void Update()
	{
		foreach (GameObject pipe in pipes)
		{
			pipe.transform.position -= new Vector3(speed * Time.deltaTime, 0f);
		}

		if (pipes[frontIndex].transform.position.x < -5f)
		{
			int backIndex = (frontIndex + count - 1) % count;
			pipes[frontIndex].transform.position = new Vector3(pipes[backIndex].transform.position.x + interval, Random.Range(-yVariance, yVariance));

			frontIndex = ++frontIndex % count;
		}
	}
}
