using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	[HideInInspector]
	public WorldManager Manager;

	public virtual void ActivateScene()
	{

	}

	public virtual void DeactivateScene()
	{

	}

	public virtual void EndVO(VOController controller)
	{

	}
}
