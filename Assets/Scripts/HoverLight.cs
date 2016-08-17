using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light))]
public class HoverLight : MonoBehaviour
{
	Light ComponentLight;
	bool bHoverable = false;
	bool bDisabling = false;

	void Start()
	{
		ComponentLight = GetComponent<Light>();
		ComponentLight.enabled = false;
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
			ComponentLight.enabled = true;
		}
	}

	public void GazeStop()
	{
		Invoke("DisableLight", 1.0f);
		bDisabling = true;
	}

	void DisableLight()
	{
		ComponentLight.enabled = false;
	}

	public void SetHoverable(bool Enable)
	{
		bHoverable = Enable;
		if (!Enable)
		{
			DisableLight();
		}
	}
}
