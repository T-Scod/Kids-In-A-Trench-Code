using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] int m_maxHP = 1;
    [SerializeField] float m_invulnerabiltyTime = 2f;
    [Header("Animations")]
    [SerializeField] Animator anim;
    [Header("Audio")]
    [SerializeField] RandomAudioPlayer hitSounds;
    [SerializeField] UnityEvent OnDeath, OnReceiveDamage, OnHitWhileInvulnerable, OnBecomeVulnerable, OnResetDamage;

    public float invulnerabiltyTime { get { return m_invulnerabiltyTime; } }
    public int maxHP { get { return m_maxHP; } }
    public int currentHP { get; private set; }
    public bool isDead { get { return currentHP <= 0; } }

    protected float m_timeSinceLastHit;
    protected Collider m_collider;

    bool isInvulnerable;

    void Start()
    {
        ResetDamage();
        m_collider = GetComponent<Collider>();
    }

    void Update()
    {
        //Turns of invulnerable
        if (isInvulnerable)
        {
            m_timeSinceLastHit += Time.deltaTime;
            if (m_timeSinceLastHit > invulnerabiltyTime)
            {
                m_timeSinceLastHit = 0f;
                isInvulnerable = false;
                OnBecomeVulnerable.Invoke();
            }
        }
    }

    public virtual void ResetDamage()
    {
        currentHP = m_maxHP;
        isInvulnerable = false;
        m_timeSinceLastHit = 0f;
        OnResetDamage.Invoke();
    }

    public virtual void TakeDamage(int damageAmount)
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
            Death();
            OnDeath.Invoke();
        }
        else
        {
            Hit();
            OnReceiveDamage.Invoke();
        }
    }
    public virtual void Hit() 
    {
        PlayRandomHitSound();

        if (anim != null)
            anim.SetTrigger("TakeDamage");
    }
    private void PlayRandomHitSound() 
    {
        if (hitSounds != null)
            hitSounds.PlayOnce();
    }
    
    public virtual void Death() {}
}