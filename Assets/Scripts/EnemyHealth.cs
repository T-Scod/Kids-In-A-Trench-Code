using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // health when the level starts
    public int m_startingHealth = 100;
    // current health of the enemy
    public int m_currentHealth;
    // speed of the dead enemies' movement through the floor
    public float m_sinkSpeed = 2.5f;
    // score amount for killing an enemy
    public int m_scoreValue = 10;

    // reference to the enemy capsule collider
    private CapsuleCollider m_capsuleCollider;
    // determines if the enemy is dead
    private bool m_isDead;
    // determines if the enemy should be sinking
    private bool m_isSinking;

    private void Awake()
    {
        // gets the components from the enemy
        m_capsuleCollider = GetComponent<CapsuleCollider>();

        // sets the current health to the starting health
        m_currentHealth = m_startingHealth;
    }

    private void Update()
    {
        // checks if the enemy should be sinking
        if(m_isSinking)
        {
            // translates the enemy down
            transform.Translate(-Vector3.up * m_sinkSpeed * Time.deltaTime);
        }
    }

    // decrements the enemy health and creates a hit particle on the hit point
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // checks if the enemy is dead
        if(m_isDead)
        {
            // exits the function
            return;
        }

        // decrements the enemy health
        m_currentHealth -= amount;

        // if the enemy health is less than or equal to 0
        if(m_currentHealth <= 0)
        {
            // sets the enemy to dead
            Death();
        }
    }

    // sets the enemy to dead
    private void Death()
    {
        // sets the dead flag to true
        m_isDead = true;
        // triggers the capsule collider
        m_capsuleCollider.isTrigger = true;
    }

    // makes the enemy sink
    public void StartSinking()
    {
        // disables the nav mesh agent
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        // sets the rigidbody to kinematic so that it ignores the geometry
        GetComponent<Rigidbody>().isKinematic = true;
        // sets the sinking flag to true
        m_isSinking = true;
        // increments the score
        ScoreManager.m_score += m_scoreValue;
        // destroys the object after 2 seconds
        Destroy(gameObject, 2.0f);
    }
}