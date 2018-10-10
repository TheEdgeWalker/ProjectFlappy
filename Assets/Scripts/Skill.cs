using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
	public readonly string name;
	public readonly float cooldown;

	private float cooldownEndTime;
	public float CooldownEndTime
	{
		get
		{
			return cooldownEndTime;
		}
	}

	public Skill(string name, float cooldown)
	{
		this.name = name;
		this.cooldown = cooldown;
		cooldownEndTime = 0f;
	}

	public void Cast()
	{
		if (IsAvailable())
		{
			cooldownEndTime = Time.time + cooldownEndTime;
			SkillImpl();
		}
	}

	protected virtual void SkillImpl()
	{
		Debug.LogError("Please implement skill!: " + name);
	}

	public bool IsAvailable()
	{
		return cooldownEndTime <= Time.time ? true : false;
	}
}
