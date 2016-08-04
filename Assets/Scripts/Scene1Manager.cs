using UnityEngine;
using System.Collections;

public class Scene1Manager : SceneManager
{
	public VOController IntroVO;

	void Awake()
	{
		IntroVO.Manager = this;
	}

	public override void ActivateScene()
	{

	}

	public override void DeactivateScene()
	{

	}

	public override void EndVO(VOController controller)
	{
		if (controller == IntroVO)
		{

		}
	}
}
