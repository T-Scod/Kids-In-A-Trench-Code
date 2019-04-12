using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSettings))]
public class RandomAudioPlayer : MonoBehaviour {
	AudioSource audioSource;
	[SerializeField] List<AudioClip> sounds;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public void PlayOnce()
	{
		var randomSound = sounds[UnityEngine.Random.Range(0, sounds.Count)];
		if (randomSound != null){
			audioSource.PlayOneShot(randomSound);
		}
	}
}
