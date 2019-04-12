using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour {
	[SerializeField] new AudioSource audio;
	[SerializeField] List<AudioClip> sounds;

	public void PlayOnce()
	{
		var randomSound = sounds[UnityEngine.Random.Range(0, sounds.Count)];
		if (randomSound != null){
			audio.PlayOneShot(randomSound);
		}
	}
}
