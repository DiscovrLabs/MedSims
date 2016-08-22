using UnityEngine;
using System.Collections;

public class ChangingVO : VOController
{
	public AudioClip[] ExtraVO;
	public string[] ExtraSubtitles;

	private int CurrentLine = 0;

	public override void PlayVO()
	{
		if (CurrentLine == 0)
		{
			base.PlayVO();
		}
		else
		{
			if (Character)
			{
				Character.SetBool("isTalking", true);
			}
			SoundPlayer.clip = ExtraVO[CurrentLine - 1];
			SoundPlayer.Play();
			Invoke("EndVO", SoundPlayer.clip.length + 1.5f);
			Subtitles.gameObject.SetActive(true);
			Background.SetActive(true);
			Subtitles.SetString(ExtraSubtitles[CurrentLine - 1]);
		}
	}
	protected override void EndVO()
	{
		if (Character)
		{
			Character.SetBool("isTalking", false);
		}
		Subtitles.gameObject.SetActive(false);
		Background.SetActive(false);
		CurrentLine++;
		bFinished = true;
		Manager.EndVO(this);
		if (CurrentLine > ExtraSubtitles.Length || CurrentLine > ExtraVO.Length)
		{
			if (bDisableWhenFinished)
			{
				this.gameObject.SetActive(false);
			}
			else
			{
				CurrentLine--;
			}
		}
	}
}
