using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    // reference to the enemy
    public GameObject m_enemy;
    // the wait time between spawning
    public float m_spawnTime = 3.0f;
    public int enemyCount = 10;

    // reference to the player's health
    private PlayerHealth m_playerHealth;
    private List<GameObject> m_enemies = new List<GameObject>();

    private void Start()
    {
        m_playerHealth = FindObjectOfType<PlayerHealth>();
        // repeats the spawn function with a wait time
        InvokeRepeating("Spawn", m_spawnTime, m_spawnTime);
    }

    // spawns an enemy
    private void Spawn()
    {
        // checks if the player does not have any health
        if(m_playerHealth.currentHP <= 0.0f)
        {
            // exits the function
            return;
        }

        if (m_enemies.Count <= enemyCount)
        {
            // creates a game object of the enemy type at the spawn point
            m_enemies.Add(Instantiate(m_enemy, transform.position, transform.rotation) as GameObject);
        }
    }
}