using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Skill
{
	public struct Data
	{
		public string name;
		public float cooldown;
		public bool isCancelable;
	}
	private readonly Data data;

	public SkillManager skillManager;

	public readonly string name;
	public readonly float cooldown;
	public readonly bool isCancelable;

	private List<GameObject> observers = new List<GameObject>();

	protected Skill(Skill.Data data)
	{
		this.data = data;
	}

	protected Skill(string name, float cooldown, bool isCancelable)
	{
		this.name = name;
		this.cooldown = cooldown;
		this.isCancelable = isCancelable;
	}

	public float cooldownEndTime
	{
		get;
		private set;
	}

	public bool isAvailable
	{
		get
		{
			return cooldownEndTime <= Time.time ? true : false;
		}
	}

	public void Cast()
	{
		cooldownEndTime = Time.time + cooldown;
		SkillImpl();

		foreach (GameObject observer in observers)
		{
			ExecuteEvents.Execute<ISkillMessageTarget>(observer, null, (target, data) => target.Cast(cooldownEndTime));
		}
	}

	protected abstract void SkillImpl();

	public void AddObserver(GameObject observer)
	{
		observers.Add(observer);
	}
}
