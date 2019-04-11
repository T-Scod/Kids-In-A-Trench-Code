using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // reference to the player's health
    public PlayerHealth m_playerHealth;
    // reference to the enemy
    public GameObject m_enemy;
    // the wait time between spawning
    public float m_spawnTime = 3.0f;
    // collection of spawn locations
    public Transform[] m_spawnPoints;

    private void Start()
    {
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

        // picks a random spawn point from the collection of spawn points
        int spawnPointIndex = Random.Range(0, m_spawnPoints.Length);
        // creates a game object of the enemy type at the spawn point
        Instantiate(m_enemy, m_spawnPoints[spawnPointIndex].position, m_spawnPoints[spawnPointIndex].rotation);
    }
}