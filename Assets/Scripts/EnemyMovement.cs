using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    // what the enemy is going to move towards
    private Transform m_player;
    // the health of the player
    private PlayerHealth m_playerHealth;
    // the health of the enemy
    private EnemyHealth m_enemyHealth;
    // reference to the nav mesh agent of the enemy
    private UnityEngine.AI.NavMeshAgent m_nav;

    private void Awake()
    {
        // finds a player object and sets the transform
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        // gets the components from the object
        m_playerHealth = m_player.GetComponent<PlayerHealth>();
        m_enemyHealth = GetComponent<EnemyHealth>();
        m_nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        // checks if both the enemy and the player are alive
        if (m_enemyHealth.m_currentHealth > 0 && m_playerHealth.m_currentHealth > 0)
        {
            // moves the object towards the player
            m_nav.SetDestination(m_player.position);
        }
        else
        {
            // disables the navmesh
            m_nav.enabled = false;
        }
    }
}