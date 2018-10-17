using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
	public readonly Bird owner;

	public Skill currentSkill
	{
		get;
		private set;
	}

	private readonly List<Skill> skills = new List<Skill>();

	public SkillManager(Bird owner)
	{
		this.owner = owner;

		this.currentSkill = null;
	}

	public void CastSkill(int index)
	{
		if (skills == null || skills.Count <= index)
		{
			Debug.LogError("Cannot cast skill, invalid index: " + index);
			return;
		}

		if (currentSkill != null && !currentSkill.isCancelable)
		{
			Debug.Log("Cannot cast skill, current skill is not finished: " + currentSkill.name);
			return;
		}

		Skill skill = skills[index];
		if (!skill.isAvailable)
		{
			Debug.Log("Cannot cast skill, currently on cooldown: " + skill.name);
			return;
		}

		currentSkill = skill;
		currentSkill.Cast();
	}

	public void SkillEnd()
	{
		currentSkill = null;
	}

	public void AddSkill(Skill skill)
	{
		skill.skillManager = this;
		skills.Add(skill);
	}
}
