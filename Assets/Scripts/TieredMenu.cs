using UnityEngine;
using System.Collections.Generic;

public class TieredMenu : MonoBehaviour
{
	public GameObject ButtonBP;
	public ButtonTierData[] ButtonData;
	
	List<GameObject> ButtonList = new List<GameObject>();
	int PrevTier = 0;
	int CurrentTier = 99;
	bool bEndTier = false;

	// Use this for initialization
	void Start ()
	{
		//Spawn the first set of buttons
		SpawnButtons(0);
	}

	public void ReceiveClick(int ID)
	{
		if (bEndTier)
		{
			//Handle the differing clicks
			HandleClick(ID);
		}
		else
		{
			DestroyButtons();
			SpawnButtons(ID);
		}
	}

	void SpawnButtons(int TargetID)
	{
		if (CurrentTier != TargetID)
		{
			CurrentTier = TargetID;
			ButtonTierData TargetData = ButtonData[TargetID];
			PrevTier = TargetData.PreviousID;
			bEndTier = TargetData.bEndTier;

			for (int i = 0; i < TargetData.ButtonStrings.Length; i++)
			{
				//Spawn and setup buttons
				GameObject temp = Instantiate(ButtonBP, transform.position, transform.rotation) as GameObject;
				temp.transform.SetParent(transform);
				temp.transform.localScale = new Vector3(0.5f, 0.5f, 1);
				temp.GetComponent<RectTransform>().anchoredPosition = Vector2.up * (i * 16);
				temp.GetComponent<TieredButton>().SetupButton(this, TargetData.ButtonIDs[i], TargetData.ButtonStrings[i]);
				ButtonList.Add(temp);
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

	public void BackButton()
	{
		SpawnButtons(PrevTier);	
	}

	protected virtual void HandleClick(int ID)
	{

	}
}

[System.Serializable]
public class ButtonTierData
{
	public string[] ButtonStrings;
	public int[] ButtonIDs;
	public int PreviousID;
	public bool bEndTier;
}
