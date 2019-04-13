using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] float m_sinkSpeed = 2.5f;
    [SerializeField] int m_scoreValue = 10;

    CapsuleCollider col;
    Rigidbody rb;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isDead)
        {
            transform.Translate(Vector3.down * m_sinkSpeed * Time.deltaTime);
        }
    }

    public override void Death()
    {
        //Stop and fall through the floor
        col.enabled = false;
        col.isTrigger = true;
        rb.velocity = new Vector3(0,0,0);
        // rb.useGravity = true;
        // rb.constraints = RigidbodyConstraints.None;

        //Add to score
        ScoreManager.score += m_scoreValue;

        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponentInParent<EnemyManager>().IncEnemies();

        //Clean up
        Destroy(gameObject, 1.5f);
    }
}