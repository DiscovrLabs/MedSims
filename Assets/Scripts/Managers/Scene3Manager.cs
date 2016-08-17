using UnityEngine;
using System.Collections;

public class Scene3Manager : SceneManager
{
	[Header("VO")]
	public GameObject SurgIcon;
	public VOController SurgVO;
	public HoverableMenu SurgMenu;
	
	bool bSurgeonActive = false;

	void Awake()
	{
		SurgVO.Manager = this;
	}

	public override void ActivateScene()
	{
		Invoke("ChangeMonitor", 3.0f);
	}

	public override void EndVO(VOController controller)
	{
		if (controller == SurgVO)
		{

		}
	}

	public override void Proceed()
	{
	}

	void ChangeMonitor()
	{
		//Change monitor state and tone
		SurgIcon.SetActive(true);
		SurgMenu.SetHoverable(true);
	}

	public void ClickSurgeon(bool Button)
	{
		if (Button)
		{
			SurgIcon.SetActive(false);
			SurgMenu.SetHoverable(false);
			SurgVO.PlayVO();
			bSurgeonActive = true;
		}
		else
		{
			if (bSurgeonActive && !SurgVO.GetPlaying())
			{
				SurgVO.PlayVO();
			}
		}
	}
}
