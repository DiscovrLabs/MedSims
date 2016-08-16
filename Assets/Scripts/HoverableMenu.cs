using UnityEngine;
using System.Collections;

public class HoverableMenu : MonoBehaviour
{
	public GameObject MenuChild;

	bool bHoverable = false;
	bool bDisabling = false;

	void Start()
	{
		MenuChild.SetActive(false);
	}

	public void GazeStart()
	{
		if (bHoverable)
		{
			if (bDisabling)
			{
				bDisabling = false;
				CancelInvoke();
			}
			MenuChild.SetActive(true);
		}
	}

	public void GazeStop()
	{
		Invoke("DisableMenu", 1.0f);
		bDisabling = true;
	}

	void DisableMenu()
	{
		MenuChild.SetActive(false);
	}

	public void SetHoverable(bool Enable)
	{
		bHoverable = Enable;
		if (!Enable)
		{
			DisableMenu();
		}
	}
}
