using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	private SpriteRenderer[] backgrounds;

	private float screenRight;

	private Bird bird;

	private void Start()
	{
		backgrounds = GetComponentsInChildren<SpriteRenderer>();

		Camera camera = Camera.main.GetComponent<Camera>();
		float cameraWidth = camera.orthographicSize * Screen.width / Screen.height;
		screenRight = camera.transform.position.x + cameraWidth;

		bird = FlappyManager.instance.bird;
	}

	private void Update()
	{
		SpriteRenderer leftBackground = null;
		float left = float.MaxValue;
		float right = float.MinValue;
		foreach (SpriteRenderer background in backgrounds)
		{
			background.transform.position -= new Vector3(bird.speed / 2 * Time.deltaTime, 0f);

			if (left > background.bounds.min.x)
			{
				leftBackground = background;
				left = background.bounds.min.x;
			}

			if (right < background.bounds.max.x)
			{
				right = background.bounds.max.x;
			}
		}

		if (right < screenRight && leftBackground)
		{
			float backgroundWidth = leftBackground.bounds.max.x - leftBackground.bounds.min.x;
			leftBackground.transform.position += new Vector3(backgroundWidth * (backgrounds.Length), 0f);
		}
	}
}
