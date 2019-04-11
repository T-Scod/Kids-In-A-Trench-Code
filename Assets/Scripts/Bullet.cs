using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
	[SerializeField] int damage = 1;
	[SerializeField] float mass = 0.5f;
	[SerializeField] bool affectedByGravity = true;
	[Header("Audio")]
	[SerializeField] new AudioSource audio;
	[SerializeField] List<AudioClip> hitSounds;
	[Header("Particles")]
	[SerializeField] ParticleSystem particles;

	protected GameObject m_owner;

	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.mass = mass;
		rb.useGravity = affectedByGravity;
	}

	public void SetOwner(GameObject owner)
	{
		m_owner = owner;
	}

	void OnTriggerEnter(Collider other)
	{
		//Retrive damageable
		Damageable dam = other.GetComponent<Damageable>();

		//Exit if nothing hit
		if (dam == null) return;

		//Prevent self harm
		if (dam.gameObject == m_owner) return;

		//Do the damage!
		dam.TakeDamage(damage);

		//Play a sound
		PlayRandomSound();

		//Particles!
		if (particles != null) particles.Play();

		//Clean up
		Destroy(gameObject);
	}

    void PlayRandomSound()
    {
		if (hitSounds != null) return;		//Make sure there are sounds first
		var randomSound = hitSounds[UnityEngine.Random.Range(0, hitSounds.Count)];
        audio.PlayOneShot(randomSound);
    }

}