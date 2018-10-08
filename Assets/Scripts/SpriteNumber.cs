using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteNumber : MonoBehaviour
{
	public int value = 0;
	public float changeRate = 1f;

	public Sprite[] source;
	public SpriteRenderer[] display;

	private float displayedValue = 0;

	private void OnEnable()
	{
		displayedValue = value;
		ResetDisplay();
	}

	private void FixedUpdate()
	{
		if (displayedValue == value)
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
		int digits = intValue < 10 ? 1 : ((int)System.Math.Log10(intValue)) + 1;

		for (int i = display.Length - 1; i >= 0; --i)
		{
			if (i < display.Length - digits)
			{
				display[i].gameObject.SetActive(false);
			}
			else
			{
				display[i].gameObject.SetActive(true);
				int digit = intValue % 10;
				display[i].sprite = source[digit];
				intValue /= 10;
			}
		}
	}
}
