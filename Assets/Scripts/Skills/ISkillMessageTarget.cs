using UnityEngine.EventSystems;

public interface ISkillMessageTarget : IEventSystemHandler
{
	void Cast();
}
