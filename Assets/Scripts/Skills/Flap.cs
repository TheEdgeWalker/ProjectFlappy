using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : Skill
{
	public Flap() : base("Flap", 0.5f, false)
	{
	}

	protected override void SkillImpl()
	{
		skillManager.owner.TriggerAnimation("Flap");
		skillManager.owner.AddForce(Vector2.up * 3f);
	}
}
