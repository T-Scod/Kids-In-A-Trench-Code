using System;
using UnityEngine;

public abstract class Damageable {
	[SerializeField] float HP;
	[SerializeField] AudioClip hitSound;

	public virtual void TakeDamage(int damage)
	{
		HP -= damage;
		PlayHitSound();
		
		if (HP <= 0)
		{
			Death();
		}
	}

    private void PlayHitSound()
    {
        throw new NotImplementedException();
    }

    public abstract void Death();




    [SerializeField] float startingHealth;
	[SerializeField] bool invulnerableAfterDamage;
	[SerializeField] float invulnerabilityDuration;



}
