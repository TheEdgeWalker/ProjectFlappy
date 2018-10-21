using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public static DataManager instance
	{
		get;
		private set;
	}

	public SkillDataSheet skillDataSheet = new SkillDataSheet();

	private void Awake()
	{
		instance = this;
	}
}
