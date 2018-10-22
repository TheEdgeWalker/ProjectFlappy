using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : Skill
{
	public Brake(Data data) : base(data)
	{
	}

	protected override void SkillImpl()
	{
		skillManager.owner.TriggerAnimation("Brake");
		skillManager.owner.Brake(1f);
	}
}
