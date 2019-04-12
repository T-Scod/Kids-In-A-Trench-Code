using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour {

	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform muzzle;
	[SerializeField] float launchForce = 750;
	[SerializeField] float minTimeBetweenShots = 0.25f;
	[SerializeField] float bulletLifetime = 3f;
	[Header("Animations")]
	[SerializeField] new AudioSource audio;
	[SerializeField] List<AudioClip> shootSounds;

	float timeSinceLastShot = 0f;

	void Update()
	{
		timeSinceLastShot += Time.deltaTime;
	}

	public virtual void Attack()
	{

	}

}
