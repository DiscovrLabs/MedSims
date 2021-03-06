﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TieredMenu : MonoBehaviour
{
	public HoverableMenu HoverController;
	public Text MenuTitle;
	public GameObject TitleImage;
	public GameObject BackButton;

	[Space]
	public GameObject ButtonBP;
	public ButtonTierData[] ButtonData;

	[HideInInspector]
	public Scene3Manager Manager;
	
	List<GameObject> ButtonList = new List<GameObject>();
	int PrevTier = 0;
	int CurrentTier = 99;
	bool bEndTier = false;
	
	void Start ()
	{
		SpawnButtons(0);
	}

	public void ReceiveClick(int ID, int Index)
	{
		if (bEndTier)
		{
			ButtonData[CurrentTier].bButtonEnabled[Index] = false;
			HandleClick(ID);
		}
		else
		{
			SpawnButtons(ID);
		}
	}

	void SpawnButtons(int TargetID)
	{
		if (CurrentTier != TargetID)
		{
			DestroyButtons();
			ButtonTierData TargetData = ButtonData[TargetID];
			PrevTier = CurrentTier;
			CurrentTier = TargetID;
			bEndTier = TargetData.bEndTier;

			for (int i = 0; i < TargetData.ButtonStrings.Length; i++)
			{
				//Spawn and setup buttons
				GameObject temp = Instantiate(ButtonBP, transform.position, transform.rotation) as GameObject;
				temp.transform.SetParent(transform);
				temp.transform.localScale = new Vector3(0.5f, 0.5f, 1);
				temp.GetComponent<RectTransform>().anchoredPosition = Vector2.up * ((TargetData.ButtonStrings.Length / 2 - (i + 1)) * 16);
				temp.GetComponent<TieredButton>().SetupButton(this, TargetData.ButtonIDs[i], TargetData.ButtonStrings[i], TargetData.bButtonEnabled[i], i);
				ButtonList.Add(temp);
			}

			MenuTitle.text = TargetData.TitleString;
			Vector2 TitlePos = Vector2.up * ((TargetData.ButtonStrings.Length / 2) * 16);
			TitleImage.GetComponent<RectTransform>().anchoredPosition = TitlePos;
			BackButton.GetComponent<RectTransform>().anchoredPosition = TitlePos + (Vector2.right * -50);

			if (TargetID == 0)
			{
				BackButton.SetActive(false);
			}
			else
			{
				BackButton.SetActive(true);
			}
		}
	}

	void DestroyButtons()
	{
		for (int i = 0; i < ButtonList.Count; i++)
		{
			Destroy(ButtonList[i]);
		}
		ButtonList.Clear();
	}

	public void ResetMenu()
	{
		bEndTier = false;
		SpawnButtons(0);
	}

	public void BackButtonClick()
	{
		SpawnButtons(PrevTier);	
	}

	public void GazeStart()
	{
		if (HoverController)
		{
			HoverController.GazeStart();
		}
	}

	public void GazeStop()
	{
		if (HoverController)
		{
			HoverController.GazeStop();
		}
	}

	protected virtual void HandleClick(int ID)
	{
		if (Manager)
		{
			switch (ID)
			{
				case 1:
					Manager.ChooseOption(false);
					break;
				case 2:
					Manager.ChooseOption(true);
					break;
				default:
					break;
			}
		}
		ResetMenu();
	}
}

[System.Serializable]
public class ButtonTierData
{
	public string TitleString;
	public string[] ButtonStrings;
	public int[] ButtonIDs;
	public bool[] bButtonEnabled;
	[Space]
	public bool bEndTier;
}
