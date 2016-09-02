using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TieredButton : MonoBehaviour
{
	public Text ButtonText;

	protected TieredMenu ParentMenu;
	protected int ButtonID = 0;
	protected int ButtonIndex = 0;

	public void ClickButton()
	{
		ParentMenu.ReceiveClick(ButtonID, ButtonIndex);
	}

	public void SetupButton(TieredMenu Parent, int _ID, string _Text, bool bEnabled, int Index)
	{
		ParentMenu = Parent;
		ButtonID = _ID;
		ButtonText.text = _Text;
		ButtonIndex = Index;
		if (bEnabled == false)
		{
			GetComponent<Button>().interactable = false;
		}
	}

	public void GazeStart()
	{
		ParentMenu.GazeStart();
	}

	public void GazeStop()
	{
		ParentMenu.GazeStop();
	}
}
