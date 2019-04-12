using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] int maxHP = 1;
    [SerializeField] float invulnerabiltyTime = 2f;
    [Header("Animations")]
    [SerializeField] Animator anim;
    [Header("Audio")]
    [SerializeField] RandomAudioPlayer hitSounds;
    [SerializeField] UnityEvent OnDeath, OnReceiveDamage, OnHitWhileInvulnerable, OnBecomeInvulnerable, OnResetDamage;


    public bool isInvulnerable;
    public int currentHP { get; private set; }
    public bool isDead { get { return currentHP <= 0; } }


    protected float m_timeSinceLastHit;
    protected Collider m_collider;


    void Start()
    {
        ResetDamage();
        m_collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (isInvulnerable)
        {
            m_timeSinceLastHit += Time.deltaTime;
            if (m_timeSinceLastHit > invulnerabiltyTime)
            {
                m_timeSinceLastHit = 0f;
                isInvulnerable = false;
                OnBecomeInvulnerable.Invoke();
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
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            OnDeath.Invoke();
            Death();
        }
        else
        {
            OnReceiveDamage.Invoke();
        }
    }

    //------- Accessible via unity events ------/
    private void PlayRandomHitSound() 
    {
        if (hitSounds != null)
            hitSounds.PlayOnce();
    }

    private void PlayRandomSound()
    {
        PlayRandomHitSound();

        if (anim != null)
            anim.SetTrigger("TakeDamage");
    }

    public virtual void Death() {}

}