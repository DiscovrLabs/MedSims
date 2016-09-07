using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class NurseAudio : MonoBehaviour
{
	public AudioClip[] AudioClips;

	public float PlayClip(int Index)
	{
		AudioSource Source = GetComponent<AudioSource>();
		Source.clip = AudioClips[Index];
		Source.Play();

		return AudioClips[Index].length;
	}
}
