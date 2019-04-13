using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    // the wait time between attacks
    public float m_timeBetweenAttacks = 1.0f;
    // damage value of the attack
    public int m_attackDamage = 1;

    // reference to the player health script
    private PlayerHealth player;
    // reference to the enemy health script
    private EnemyHealth enemy;
    // determines if the player is close enough to attack
    private bool m_playerInRange;
    // ensures that the enemy is attacking evenly
    private float timeSinceLastAttack;

    private void Awake()
    {
        // gets the components from the object
        player = FindObjectOfType<PlayerHealth>();
        enemy = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // checks if the colliding object is the player
        if(other.gameObject == player.gameObject)
        {
            // sets the flag for if the player is in range to true
            m_playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // checks if the object leaving the collider is the player
        if(other.gameObject == player.gameObject)
        {
            // sets the flag for if the player is in range to false
            m_playerInRange = false;
        }
    }

    private void Update()
    {
        // increments the timer
        timeSinceLastAttack += Time.deltaTime;

        // checks if the timer is greater than the time between attacks and the player is close enough
        if(timeSinceLastAttack >= m_timeBetweenAttacks && m_playerInRange && !enemy.isDead)
        {
            // attacks the player
            Attack();
        }
    }

    private void Attack()
    {
        // resets the timer
        timeSinceLastAttack = 0.0f;
        // checks if the player health is greater than 0
        if(!player.isDead)
        {
            // decrements the player health
            player.TakeDamage(m_attackDamage);
        }
    }
}