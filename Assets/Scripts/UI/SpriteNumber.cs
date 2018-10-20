using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteNumber : MonoBehaviour
{
	public int value = 0;
	public float changeRate = 1f;

	public Sprite[] source;
	public Image[] display;

	private float displayedValue = 0;

	private void OnEnable()
	{
		displayedValue = value;
		ResetDisplay();
	}

	private void FixedUpdate()
	{
		if ((int)displayedValue == value)
		{
			return;
		}

		float change = changeRate * Time.deltaTime;
		if (Mathf.Abs(value - displayedValue) < change)
		{
			displayedValue = value;
		}
		else
		{
			if (displayedValue < value)
			{
				displayedValue += change;
			}
			else
			{
				displayedValue -= change;
			}
		}

		ResetDisplay();
	}

	private void ResetDisplay()
	{
		int intValue = (int)displayedValue;

		for (int i = 0; i < display.Length; ++i)
		{
			if (i == 0 || intValue > 0)
			{
				display[i].gameObject.SetActive(true);
				int digit = intValue % 10;
				display[i].sprite = source[digit];
				intValue /= 10;
			}
			else
			{
				display[i].gameObject.SetActive(false);
			}
		}
	}
}
