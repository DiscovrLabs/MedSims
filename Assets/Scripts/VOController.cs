using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class VOController : MonoBehaviour
{
	public TextController Subtitles;
	public GameObject Background;

	[HideInInspector]
	public SceneManager Manager;

	AudioSource SoundPlayer;

	void Awake()
	{
		SoundPlayer = GetComponent<AudioSource>();
	}

	void Start ()
	{
		Subtitles.gameObject.SetActive(false);
		Background.SetActive(false);
	}
	
	//Function for handling varying clicks
	public void OnClick()
	{
		//Start audio and text
		if (!SoundPlayer.isPlaying)
		{
			PlayVO();
		}
		else
		{
			if (!Subtitles.bFinishedTyping)
			{
				//Skip text scrolling
				Subtitles.SkipTyping();
			}
			else
			{
				//Skip VO
				SoundPlayer.Stop();
				CancelInvoke();
				EndVO();
			}
		}
	}

	public void PlayVO()
	{
		SoundPlayer.Play();
		Invoke("EndVO", SoundPlayer.clip.length + 1.5f);
		Subtitles.gameObject.SetActive(true);
		Background.SetActive(true);
		Subtitles.StartTyping();
	}

	void EndVO ()
	{
		Manager.EndVO(this);
		this.gameObject.SetActive(false);
	}
}
