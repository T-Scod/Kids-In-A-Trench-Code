using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] float m_sinkSpeed = 2.5f;
    [SerializeField] int m_scoreValue = 10;

    CapsuleCollider m_capsuleCollider;

    private void Awake()
    {
        m_capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        // checks if the enemy should be sinking
        if(isDead)
        {
            // translates the enemy down
            transform.Translate(-Vector3.up * m_sinkSpeed * Time.deltaTime);
        }
    }

    public override void Death()
    {
        // triggers the capsule collider (because if you disable it, it won't collide with anything and gravity would just take over?)
        m_capsuleCollider.isTrigger = true;
        StartSinking();
    }

    // makes the enemy sink
    public void StartSinking()
    {
        // disables the nav mesh agent
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        // sets the rigidbody to kinematic so that it ignores the geometry
        GetComponent<Rigidbody>().isKinematic = true;
        // sets the sinking flag to true
        // increments the score
        ScoreManager.m_score += m_scoreValue;
        // destroys the object after 2 seconds
        Destroy(gameObject, 2.0f);
    }
}