using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireForce = 100f;
    [SerializeField] ForceMode fireForceMode = ForceMode.Impulse;

    public float m_timeBetweenBullets = 0.15f;

    // ensures that the player can only shoot when the time is right
    private float m_timer;

    // used to cast out and hit something
    // private Ray m_shootRay = new Ray();
    // // used to get information about what was hit
    // private RaycastHit m_shootHit;
    // how far the bullets can go
    // public float m_range = 100.0f;
    // // the damage value of a shot
    // public int m_damagePerShot = 20;
    // // wait time between firing

    private void Update()
    {
        // increments the timer
        m_timer += Time.deltaTime;

        // checks if the fire button was pressed, the timer is greater than the time between firing and the rate of which time is passing is not 0
		if(Input.GetButton("Fire1") && m_timer >= m_timeBetweenBullets && Time.timeScale != 0.0f)
        {
            // shoots a bullet
            Shoot();
        }
    }

    // shoots a bullet
    private void Shoot()
    {
        // resets the timer
        m_timer = 0.0f;

        var newBullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
        var projectile = newBullet.GetComponent<Projectile>();
        projectile.Launch(transform, fireForce, fireForceMode);


        // // sets the origin of the shoot ray to the gun barrel position
        // m_shootRay.origin = transform.position;
        // // sets the direction of the shoot ray to the direction the gun is facing
        // m_shootRay.direction = transform.forward;

        // // checks if the shoot ray hits a shootable object and gets information about the object
        // if(Physics.Raycast(m_shootRay, out m_shootHit, m_range))
        // {
        //     // gets the health of the enemy shot
        //     EnemyHealth enemyHealth = m_shootHit.collider.GetComponent<EnemyHealth>();
        //     // checks if the object has a health script
        //     if(enemyHealth != null)
        //     {
        //         // decrements the enemy health
        //         enemyHealth.TakeDamage(m_damagePerShot, m_shootHit.point);
        //     }
        // }
    }
}