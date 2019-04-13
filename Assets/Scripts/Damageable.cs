using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] int m_maxHP = 2;
    public float invulnerableTime = 0.1f;
    [Header("Animations")]
    [SerializeField] Animator anim;
    [Header("Audio")]
    [SerializeField] RandomAudioPlayer hitSounds;
    [SerializeField] UnityEvent OnDeath, OnReceiveDamage, OnHitWhileInvulnerable, OnBecomeVulnerable, OnResetDamage;

    public int maxHP { get { return m_maxHP; } }
    public bool isInvulnerable { get; set; }
    public int currentHP { get; private set; }
    public bool isDead { get { return currentHP <= 0; } }

    protected float m_timeSinceLastHit;
    protected Collider m_collider;


    void Start()
    {
        ResetDamage();
        m_collider = GetComponent<Collider>();
    }

    void LateUpdate()	//This must not be blocked by derived classes!!!
    {
        if (isInvulnerable)
        {
            m_timeSinceLastHit += Time.deltaTime;
            if (m_timeSinceLastHit > invulnerableTime)
            {
                m_timeSinceLastHit = 0f;
                isInvulnerable = false;
                OnBecomeVulnerable.Invoke();
            }
        }
    }

    public void ResetDamage()
    {
        currentHP = maxHP;
        isInvulnerable = false;
        m_timeSinceLastHit = 0f;
        OnResetDamage.Invoke();
    }

	public void SetColliderState(bool enabled)
	{
		m_collider.enabled = enabled;
	}


    public void TakeDamage(int damageAmount)
    {
        //Ignore damage if already dead
        if (isDead) return;

        if (isInvulnerable)
        {
            OnHitWhileInvulnerable.Invoke();
            return;
        }

        //Finally take damage
		isInvulnerable = true;
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            OnDeath.Invoke();
            Death();
        }
        else
        {
            OnReceiveDamage.Invoke();
            Hit();
        }
    }

    //------- Accessible via unity events ------/
    private void PlayHitSound() 
    {
        hitSounds.PlayOnce();
    }

    //Virtual methods that do nothing but can be overriden and implementd by the children
    public virtual void Hit() 
    {
        PlayHitSound();

        if (anim != null)
            anim.SetTrigger("TakeDamage");
    }
    public virtual void Death() {}
}