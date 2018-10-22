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
		if (skills == null || skills.Count <= index || index < 0)
		{
			Debug.LogError("Cannot cast skill, invalid index: " + index);
			return;
		}

		if (currentSkill != null && !currentSkill.data.isCancelable)
		{
			Debug.Log("Cannot cast skill, current skill is not finished: " + currentSkill.data.name);
			return;
		}

		Skill skill = skills[index];
		if (!skill.isAvailable)
		{
			Debug.Log("Cannot cast skill, currently on cooldown: " + skill.data.name);
			return;
		}

		currentSkill = skill;
		currentSkill.Cast();
	}

	public void SkillEnd()
	{
		currentSkill = null;
	}

	public void AddSkill(string name)
	{
		Skill skill = DataManager.instance.skillDataSheet.GenerateSkill(name);
		skill.skillManager = this;
		skills.Add(skill);
	}

	public Skill.Data GetSkillData(int index)
	{
		if (IsInvalidIndex(index))
		{
			Debug.LogError("Cannot get Skill data, invalid index: " + index);
			return new Skill.Data();
		}

		return skills[index].data;
	}

	public void AddObserver(GameObject observer, int index)
	{
		if (IsInvalidIndex(index))
		{
			Debug.LogError("Cannot add observer, invalid index: " + index);
			return;
		}

		skills[index].AddObserver(observer);
	}

	private bool IsInvalidIndex(int index)
	{
		return skills == null || skills.Count <= index || index < 0;
	}
}
