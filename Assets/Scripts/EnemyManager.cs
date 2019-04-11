using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // reference to the enemy
    public GameObject m_enemy;
    // the wait time between spawning
    public float m_spawnTime = 3.0f;
    // reference to the player's health
    private PlayerHealth m_playerHealth;

    private void Start()
    {
        m_playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        // repeats the spawn function with a wait time
        InvokeRepeating("Spawn", m_spawnTime, m_spawnTime);
    }

    // spawns an enemy
    private void Spawn()
    {
        // checks if the player does not have any health
        if(m_playerHealth.m_currentHealth <= 0.0f)
        {
            // exits the function
            return;
        }


        // creates a game object of the enemy type at the spawn point
        Instantiate(m_enemy, transform.position, transform.rotation);
    }
}