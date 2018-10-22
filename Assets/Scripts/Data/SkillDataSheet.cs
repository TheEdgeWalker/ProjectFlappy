using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataSheet : DataSheet<Skill.Data>
{
	public SkillDataSheet() : base("Assets/Data/Skills")
	{
	}

	public Skill GenerateSkill(string name)
	{
		Skill.Data data = GetRow(name);
		return (Skill)Activator.CreateInstance(Type.GetType(name), data);
	}
}
