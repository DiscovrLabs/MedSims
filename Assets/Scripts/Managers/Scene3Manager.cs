using UnityEngine;
using System.Collections;

public class Scene3Manager : SceneManager
{
	public GameObject Scene3a;
	public GameObject Scene3b;
	public NurseAudio NurseVO;
	[Header("Scene 3A")]
	public GameObject SurgIcon;
	public VOController SurgVO;
	public HoverableMenu[] MenusA;

	[Header("Scene 3B")]
	public HoverableMenu[] MenusB;

	int CorrectActions = 0;
	bool bSurgeonActive = false;

	void Awake()
	{
		SurgVO.Manager = this;
	}

	public override void EnableScene()
	{
		Scene.SetActive(true);
	}

	public override void DeactivateScene()
	{
		Destroy(Scene);
		Destroy(Scene3a);
		Destroy(Scene3b);
	}

	public override void ActivateScene()
	{
		Invoke("ChangeMonitor", 5.0f);
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

	public void ChooseOption(bool bShouldDie)
	{
		if(bShouldDie)
		{
			Scene3b.SetActive(false);
			float delay = NurseVO.PlayClip(3);
			Invoke("TriggerFailure", delay);
		}
		else
		{
			CorrectActions++;
			if (CorrectActions >= 7)
			{
				Scene3b.SetActive(false);
				Manager.SetWinState(true);
			}
		}
	}

	void ChangeMonitor()
	{
		//Change monitor state and tone
		Scene3a.SetActive(true);
		SurgIcon.SetActive(true);
		NurseVO.PlayClip(0);
		for (int i = 0; i < MenusA.Length; i++)
		{
			MenusA[i].SetHoverable(true);
		}
		Invoke("TriggerEmergency", 45.0f);
	}

	void TriggerEmergency()
	{
		//Trigger scene 3.1
		Scene3a.SetActive(false);
		Scene3b.SetActive(true);
		NurseVO.PlayClip(1);
	}

	void TriggerFailure()
	{
		Manager.SetWinState(false);
	}

	public void ClickSurgeon(bool Button)
	{
		if (Button)
		{
			SurgIcon.SetActive(false);
			MenusA[0].SetHoverable(false);
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
