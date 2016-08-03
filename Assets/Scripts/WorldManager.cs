using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	[Header("World Data")]
	public SceneManager[] Scenes;
	public Vector3[] ScenePositions;
	public Vector3[] SceneRotations;
	
	[Header ("Player Data")]
	public GameObject Player;

	protected int SceneState = 0;

	// Use this for initialization
	void Start ()
	{
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
}
