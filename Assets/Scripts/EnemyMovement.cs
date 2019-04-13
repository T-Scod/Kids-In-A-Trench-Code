using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    // what the enemy is going to move towards
    private PlayerHealth player;
    // the health of the enemy
    private EnemyHealth enemy;
    // reference to the nav mesh agent of the enemy
    private UnityEngine.AI.NavMeshAgent m_nav;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        enemy = GetComponent<EnemyHealth>();
        m_nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        // checks if both the enemy and the player are alive
        if (!enemy.isDead && !player.isDead)
        {
            // pathfinds the object towards the player
            m_nav.SetDestination(player.transform.position);
            m_nav.speed += Time.deltaTime;
        }
        else
        {
            // disables the navmesh
            m_nav.enabled = false;
        }
    }
}