using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, ISkillMessageTarget
{
	public int skillIndex;
	public Image foreGround;

	private float skillCastTime = 0f;
	private float cooldownEndTime = 0f;

	private void Start()
	{
		if (foreGround.type != Image.Type.Filled)
		{
			Debug.LogError("Foreground is not Filled: " + name);
			return;
		}
	}

	private void Update()
	{
		if (Time.time >= cooldownEndTime)
		{
			foreGround.gameObject.SetActive(false);
		}
		else
		{
			foreGround.gameObject.SetActive(true);

			float remainingTime = cooldownEndTime - Time.time;
			float totalDuration = cooldownEndTime - skillCastTime;
			foreGround.fillAmount = remainingTime / totalDuration;
		}
	}

	public void Cast(float cooldownEndTime)
	{
		Debug.Log("I see that skill is Cast!: " + name);
		this.skillCastTime = Time.time;
		this.cooldownEndTime = cooldownEndTime;
	}
}
