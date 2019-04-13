using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour {

	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform muzzle;
	// [SerializeField] float launchForce = 750;
	// [SerializeField] float minTimeBetweenShots = 0.25f;
	// [SerializeField] float bulletLifetime = 3f;

	[Header("Audio")]
	[SerializeField] RandomAudioPlayer attackSounds;


	Animator anim;
	float timeSinceLastAttack = 0f;
	

	void Update()
	{
		timeSinceLastAttack += Time.deltaTime;
	}

	public virtual void Attack()
	{

	}

}
