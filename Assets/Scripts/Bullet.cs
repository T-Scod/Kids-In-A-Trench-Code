using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	[SerializeField] int damage = 1;
    [SerializeField] bool destroyOnContact = true;
	[Header("Physics")]
	[SerializeField] float mass = 0.5f;
	[SerializeField] bool affectedByGravity = true;
	[Header("Audio")]
	[SerializeField] RandomAudioPlayer randomAudio;
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

	void Start()
	{
		// Assert.IsNotNull(randomAudio);
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
		if (destroyOnContact)
			Destroy(gameObject);
	}

    void PlayRandomSound()
    {
		randomAudio.PlayOnce();
    }

}