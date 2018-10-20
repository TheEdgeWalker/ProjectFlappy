using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, ISkillMessageTarget
{
	public int skillIndex;
	public Image foreGround;

	private void Start()
	{
		if (foreGround.type != Image.Type.Filled)
		{
			Debug.LogError("Foreground is not Filled: " + name);
			return;
		}
	}

	public void Cast(float cooldownEndTime)
	{
		Debug.Log("I see that skill is Cast!: " + name);
	}
}
