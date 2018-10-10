using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
	private List<Skill> skills = new List<Skill>();

	public SkillManager()
	{
		skills.Add(new Skill("Flap", 0.5f));
		skills.Add(new Skill("Loiter", 5f));
	}

	public Skill GetSkill(int index)
	{
		if (index >= skills.Count)
		{
			return null;
		}

		return skills[index];
	}
}
