using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    // reference to the enemy
    public GameObject m_enemy;
    // the wait time between spawning
    public float spawnDelay = 3.0f;
    public int maxEnemiesPerSpawner = 10;
    public List<GameObject> m_enemies = new List<GameObject>();

    // reference to the player's health
    private PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        // repeats the spawn function with a wait time
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    // spawns an enemy
    private void Spawn()
    {
        // checks if the player does not have any health
        if(player.isDead)
        {
            // exits the function
            return;
        }

        if (m_enemies.Count < maxEnemiesPerSpawner)
        {
            // creates a game object of the enemy type at the spawn point
            m_enemies.Add(Instantiate(m_enemy, transform.position, transform.rotation) as GameObject);
            m_enemies[m_enemies.Count-1].GetComponent<EnemyHealth>().manager = this;
        }
    }

    public void RemoveFromManager(GameObject enemyToBeRemoved)
    {
        m_enemies.Remove(enemyToBeRemoved);
    }
}