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
	private bool bFadeComplete;

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
		Scenes[0].ActivateScene();
		//trigger fade in and default position
	}

	//Advance to next Scene
	public void AdvanceState()
	{
		SceneState++;
		if (SceneState < Scenes.Length)
		{
			//Trigger Fade out and scene transition
			Scenes[SceneState].ActivateScene();
		}
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
		bFadeComplete = true;
	}
}
