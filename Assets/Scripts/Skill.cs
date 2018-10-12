using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
	public SkillManager skillManager;

	public readonly string name;
	public readonly float cooldown;
	public readonly bool isCancelable;

	protected Skill(string name, float cooldown, bool isCancelable)
	{
		this.name = name;
		this.cooldown = cooldown;
		this.isCancelable = isCancelable;
	}

	public float cooldownEndTime
	{
		get;
		private set;
	}

	public bool isAvailable
	{
		get
		{
			return cooldownEndTime <= Time.time ? true : false;
		}
	}

	public void Cast()
	{
		cooldownEndTime = Time.time + cooldownEndTime;
		SkillImpl();
	}

	protected abstract void SkillImpl();
}
