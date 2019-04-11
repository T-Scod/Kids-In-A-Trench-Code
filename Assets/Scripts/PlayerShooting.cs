using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] float launchForce = 500;
    [SerializeField] ForceMode launchForceMode = ForceMode.Impulse;
    [SerializeField] float damagePerShot = 20;
    [SerializeField] float timeBetweenShots = 0.15f;
    [SerializeField] float bulletLifetime = 3f;
    float timer;

    private void Update()
    {
        //Keep track of time for fire delay
        timer += Time.deltaTime;
    }

    public void Shoot()
    {
        //Regulate shots
        if (timer < timeBetweenShots)
            return;

        // resets the timer
        timer = 0f;

        //Instantiate
        var tempObj = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

        //Retrieve rigidbody
        var tempRB = tempObj.GetComponent<Rigidbody>();

        //Launch
        tempRB.AddForce(transform.forward * launchForce);

        //Clean up
        Destroy(tempObj, bulletLifetime);


        // sets the origin of the shoot ray to the gun barrel position
        // m_shootRay.origin = transform.position;
        // // sets the direction of the shoot ray to the direction the gun is facing
        // m_shootRay.direction = transform.forward;

        // // checks if the shoot ray hits a shootable object and gets information about the object
        // if(Physics.Raycast(m_shootRay, out m_shootHit, bulletRange))
        // {
        //     // gets the health of the enemy shot
        //     EnemyHealth enemyHealth = m_shootHit.collider.GetComponent<EnemyHealth>();
        //     // checks if the object has a health script
        //     if(enemyHealth != null)
        //     {
        //         // decrements the enemy health
        //         enemyHealth.TakeDamage(damagePerShot, m_shootHit.point);
        //     }
        // }
    }
}