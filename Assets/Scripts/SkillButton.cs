using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
	public Image foreGround;

	public Skill skill;

	private void Start()
	{
		if (foreGround.type != Image.Type.Filled)
		{
			Debug.LogError("Foreground is not Filled: " + name);
		}
	}

	private void Update()
	{
		if (skill != null)
		{

		}
	}
}
