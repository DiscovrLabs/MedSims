using UnityEngine;
using System.Collections;

public class Scene2Manager : SceneManager
{
	[Header("VO")]
	public VOController AnesthVO;
	public VOController SurgVO;
	public GameObject AnesthIcon;
	public GameObject SurgIcon;

	[Header("World")]
	public GameObject Scene2;
	public GameObject ProceedButton;
	public GameObject[] HighlightObj;

	protected int GameState = 0;

	void Awake()
	{
		AnesthVO.Manager = this;
		SurgVO.Manager = this;
	}

	public override void ActivateScene()
	{
		Scene2.SetActive(true);
		AnesthIcon.SetActive(true);
		GameState++;
	}

	public override void DeactivateScene()
	{
		Destroy(Scene2);
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
			ProceedButton.SetActive(true);
		}
	}

	public override void Proceed()
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
