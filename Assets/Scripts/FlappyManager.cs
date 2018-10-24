using UnityEngine;

public class FlappyManager : MonoBehaviour
{
	public static FlappyManager instance
	{
		get;
		private set;
	}

	public Bird bird;

	public SpriteNumber score;

	public BackgroundScroller skyScroller;
	public BackgroundScroller groundScroller;
	public PipeScroller pipeScroller;

	public SkillButton[] skillButtons;
	
	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		foreach (SkillButton skillButton in skillButtons)
		{
			bird.AddSkillObserver(skillButton.gameObject, skillButton.skillIndex);
		}
	}
}
