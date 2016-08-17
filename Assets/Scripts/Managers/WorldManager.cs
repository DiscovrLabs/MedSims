using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour
{
	[Header("World Data")]
	public SceneManager[] Scenes;
	public Vector3[] ScenePositions;
	public Vector3[] SceneRotations;
	
	[Header ("Player Data")]
	public GameObject Player;
	public VRStandardAssets.Utils.VRCameraFade FadeScript;

	protected int SceneState = 0;
	private bool bFadeOut = false;

	// Use this for initialization
	void Awake()
	{
		for (int i = 0; i < Scenes.Length; i++)
		{
			Scenes[i].Manager = this;
		}
	}

	void Start()
	{
		FadeScript.OnFadeComplete += _FadeCompleted;
		//trigger fade in and default position
		Player.transform.position = ScenePositions[SceneState];
		Player.transform.rotation = Quaternion.Euler(SceneRotations[SceneState]);
	}

	//Advance to next Scene
	public void AdvanceState()
	{
		SceneState++;
		if (SceneState < Scenes.Length)
		{
			//Trigger Fade out and scene transition
			FadeScript.FadeOut(false);
			bFadeOut = true;
		}
		else
		{
			SceneState = Scenes.Length - 1;
		}
	}

	void FadeIn()
	{
		//Transition location and setup scene, then fade in
		bFadeOut = false;
		if (SceneState > 0)
		{
			Scenes[SceneState - 1].DeactivateScene();
		}
		Scenes[SceneState].EnableScene();
		Player.transform.position = ScenePositions[SceneState];
		Player.transform.rotation = Quaternion.Euler(SceneRotations[SceneState]);
		FadeScript.FadeIn(false);
	}

	void TriggerScene()
	{
		Scenes[SceneState].ActivateScene();
	}

	public void SetWinState (bool bDidWin)
	{
		if (bDidWin)
		{
			//Victory Condition
		}
		else
		{
			//Death Condition
		}
	}

	private void _FadeCompleted()
	{
		if (bFadeOut)
		{
			FadeIn();
		}
		else
		{
			TriggerScene();
		}
	}
}
