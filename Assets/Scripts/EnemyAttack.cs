using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    // the wait time between attacks
    public float m_timeBetweenAttacks = 1.0f;
    // damage value of the attack
    public int m_attackDamage = 1;

    // reference to the player
    private GameObject m_player;
    // reference to the player health script
    private PlayerHealth m_playerHealth;
    // reference to the enemy health script
    private EnemyHealth m_enemyHealth;
    // determines if the player is close enough to attack
    private bool m_playerInRange;
    // ensures that the enemy is attacking evenly
    private float m_timer;

    private void Awake()
    {
        // finds the player
        m_player = GameObject.FindGameObjectWithTag("Player");
        // gets the components from the object
        m_playerHealth = m_player.GetComponent<PlayerHealth>();
        m_enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // checks if the colliding object is the player
        if(other.gameObject == m_player)
        {
            // sets the flag for if the player is in range to true
            m_playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // checks if the object leaving the collider is the player
        if(other.gameObject == m_player)
        {
            // sets the flag for if the player is in range to false
            m_playerInRange = false;
        }
    }

    private void Update()
    {
        // increments the timer
        m_timer += Time.deltaTime;

        // checks if the timer is greater than the time between attacks and the player is close enough
        if(m_timer >= m_timeBetweenAttacks && m_playerInRange && m_enemyHealth.m_currentHealth > 0)
        {
            // attacks the player
            Attack();
        }
    }

    private void Attack()
    {
        // resets the timer
        m_timer = 0.0f;
        // checks if the player health is greater than 0
        if(m_playerHealth.m_currentHealth > 0)
        {
            // decrements the player health
            m_playerHealth.TakeDamage(m_attackDamage);
        }
    }
}