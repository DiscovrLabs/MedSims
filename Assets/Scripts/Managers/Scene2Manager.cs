using UnityEngine;
using System.Collections;

public class Scene2Manager : SceneManager
{
	public GameObject ProceedButton;
	public HoverLight[] HighlightObj;

	[Header("VO")]
	public VOController AnesthVO;
	public VOController SurgVO;
	public GameObject AnesthIcon;
	public GameObject SurgIcon;

	protected int GameState = 0;
	bool bCanProceed = true;

	void Awake()
	{
		AnesthVO.Manager = this;
		SurgVO.Manager = this;
	}

	public override void ActivateScene()
	{
		AnesthIcon.SetActive(true);
		GameState++;
	}

	public override void EndVO(VOController controller)
	{
		if(controller == AnesthVO)
		{
			//Enable Surgeon
			SurgIcon.SetActive(true);
			GameState++;
		}
		else if (controller == SurgVO)
		{
			//Enable Highlighting and proceed button
			GetComponent<AudioSource>().Play();
			for (int i = 0; i < HighlightObj.Length; i++)
			{
				HighlightObj[i].SetHoverable(true);
			}
			ProceedButton.SetActive(true);
		}
	}

	public override void Proceed()
	{
		if (bCanProceed)
		{
			Invoke("Advance", 0.2f);
			bCanProceed = false;
		}
	}

	void Advance()
	{
		ProceedButton.SetActive(false);
		Manager.AdvanceState();
		AudioSource temp = GetComponent<AudioSource>();
		if (temp.isPlaying)
		{
			temp.Stop();
		}
	}

	public void ClickActor(bool bSurgeon)
	{
		if (bSurgeon && GameState == 3)
		{
			SurgIcon.SetActive(false);
			SurgVO.PlayVO();
			GameState++;
		}
		else if (!bSurgeon && GameState == 1)
		{
			AnesthIcon.SetActive(false);
			AnesthVO.PlayVO();
			GameState++;
		}
	}
}
