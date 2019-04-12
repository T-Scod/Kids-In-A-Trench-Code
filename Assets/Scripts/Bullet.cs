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
	[SerializeField] RandomAudioPlayer impactSounds;
	[Header("Particles")]
	[SerializeField] ParticleSystem particles;
    [SerializeField] bool destroyOnContact = true;

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
		PlayImpactSound();

		//Particles!
		if (particles != null) particles.Play();

		//Clean up
		if (destroyOnContact)
			Destroy(gameObject);
	}

    void PlayImpactSound()
    {
		if (impactSounds != null)
			impactSounds.PlayOnce();
    }

}