using UnityEngine;
using System.Collections.Generic;

public class HoverLight : MonoBehaviour
{
	List<Material> ChildMaterials = new List<Material>();
	List<Color> ChildColors = new List<Color>();
	bool bHoverable = false;
	bool bDisabling = false;

	void Start()
	{
		Renderer[] temp = GetComponentsInChildren<Renderer>();
		for (int i = 0; i < temp.Length; i++)
		{
			ChildMaterials.AddRange(temp[i].materials);
		}
		for (int i = 0; i < ChildMaterials.Count; i++)
		{
			ChildColors.Add(ChildMaterials[i].color);
		}
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
			SetHighlight(true);
		}
	}

	public void GazeStop()
	{
		Invoke("DisableLight", 1.0f);
		bDisabling = true;
	}

	void DisableLight()
	{
		SetHighlight(false);
	}

	public void SetHoverable(bool Enable)
	{
		bHoverable = Enable;
		if (!Enable)
		{
			DisableLight();
		}
	}

	void SetHighlight(bool bEnable)
	{
		for (int i = 0; i < ChildMaterials.Count; i++)
		{
			ChildMaterials[i].color = (bEnable) ? Color.yellow : ChildColors[i];
		}
	}
}
