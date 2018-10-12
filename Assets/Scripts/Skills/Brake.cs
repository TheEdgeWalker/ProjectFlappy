using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : Skill
{
	public Brake() : base("Brake", 10f, false)
	{
	}

	protected override void SkillImpl()
	{
		skillManager.owner.TriggerAnimation("Brake");
		skillManager.owner.Brake(2f);
	}
}
