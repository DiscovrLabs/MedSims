using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class VOController : MonoBehaviour
{
	public TextController Subtitles;

	[HideInInspector]
	public SceneManager Manager;

	AudioSource SoundPlayer;
	bool bTextSkipped;

	void Awake()
	{
		SoundPlayer = GetComponent<AudioSource>();
	}

	void Start ()
	{
		Subtitles.gameObject.SetActive(false);
	}
	
	//Function for handling varying clicks
	public void OnClick()
	{
		//Start audio and text
		if (!SoundPlayer.isPlaying)
		{
			SoundPlayer.Play();
			Invoke("EndVO", SoundPlayer.clip.length + 1.5f);
			Subtitles.gameObject.SetActive(true);
			Subtitles.StartTyping();
		}
		else
		{
			if (!bTextSkipped)
			{
				//Skip text scrolling
				Subtitles.SkipTyping();
				bTextSkipped = true;
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

	void EndVO ()
	{
		Manager.EndVO(this);
		this.gameObject.SetActive(false);
	}
}
