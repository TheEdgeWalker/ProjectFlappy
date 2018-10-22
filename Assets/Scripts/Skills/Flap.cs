using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : Skill
{
	public Flap(Data data) : base(data)
	{
	}

	protected override void SkillImpl()
	{
		skillManager.owner.TriggerAnimation("Flap");
		skillManager.owner.AddForce(Vector2.up * 3f);
	}
}
