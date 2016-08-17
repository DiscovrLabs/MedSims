using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	[Header("World")]
	public GameObject Scene;

	[HideInInspector]
	public WorldManager Manager;

	public virtual void EnableScene()
	{
		Scene.SetActive(true);
	}

	public virtual void ActivateScene()
	{

	}

	public virtual void DeactivateScene()
	{
		Destroy(Scene);
	}

	public virtual void EndVO(VOController controller)
	{

	}

	public virtual void Proceed()
	{

	}
}
