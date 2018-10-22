using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, ISkillMessageTarget
{
	public int skillIndex;
	public Image foreGround;

	private float skillCastTime = -1f;

	private Skill.Data skillData;

	private void Start()
	{
		if (foreGround.type != Image.Type.Filled)
		{
			Debug.LogError("Foreground is not Filled: " + name);
			return;
		}

		skillData = FlappyManager.instance.bird.skillManager.GetSkillData(skillIndex);
	}

	private void Update()
	{
		float cooldownEndTime = skillCastTime + skillData.cooldown;
		if (skillCastTime < 0 || Time.time >= cooldownEndTime)
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
	
	public void Cast()
	{
		Debug.Log("I see that skill is Cast!: " + name);
		skillCastTime = Time.time;
	}
}
