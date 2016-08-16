using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class VOController : MonoBehaviour
{
	public TextController Subtitles;
	public GameObject Background;
	public bool bDisableWhenFinished = true;

	[HideInInspector]
	public SceneManager Manager;

	protected AudioSource SoundPlayer;
	protected bool bFinished = false;

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
		if (!bFinished)
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
	}

	public virtual void PlayVO()
	{
		SoundPlayer.Play();
		Invoke("EndVO", SoundPlayer.clip.length + 1.5f);
		Subtitles.gameObject.SetActive(true);
		Background.SetActive(true);
		Subtitles.StartTyping();
	}

	protected virtual void EndVO ()
	{
		bFinished = true;
		Manager.EndVO(this);
		if (bDisableWhenFinished)
		{
			this.gameObject.SetActive(false);
		}
	}

	public bool GetPlaying()
	{
		return SoundPlayer.isPlaying;
	}
}
