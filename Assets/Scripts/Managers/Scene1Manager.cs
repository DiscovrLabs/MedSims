using UnityEngine;
using System.Collections;

public class Scene1Manager : SceneManager
{
	public VOController IntroVO;
	public GameObject ProceedButton;

	void Awake()
	{
		IntroVO.Manager = this;
	}

	public override void ActivateScene()
	{
		IntroVO.PlayVO();
	}

	public override void EndVO(VOController controller)
	{
		if (controller == IntroVO)
		{
			ProceedButton.SetActive(true);
		}
	}

	public override void Proceed()
	{
		ProceedButton.SetActive(false);
		Manager.AdvanceState();
	}
}
