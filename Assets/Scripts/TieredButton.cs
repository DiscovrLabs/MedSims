using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TieredButton : MonoBehaviour
{
	public Text ButtonText;

	protected TieredMenu ParentMenu;
	protected int ButtonID = 0;

	public void ClickButton()
	{
		ParentMenu.ReceiveClick(ButtonID);
	}

	public void SetupButton(TieredMenu Parent, int _ID, string _Text)
	{
		ParentMenu = Parent;
		ButtonID = _ID;
		ButtonText.text = _Text;
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
