using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Guns")]
    [SerializeField] List<Gun> guns;
    Gun currentGun;
    private int gunIndex = 0;

    [SerializeField] UnityEvent OnShoot;
    
    float timer;

    private void Update()
    {
        //Keep track of time for fire delay
        timer += Time.deltaTime;
    }

    public void Shoot()
    {
        // Debug.Log("Shooter calls Gun Fire");
        currentGun.Fire();
        OnShoot.Invoke();
    }

        // resets the timer
        timer = 0f;

        //Instantiate
        var tempObj = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

        //Set the bullet's owner to prevent self harm
        tempObj.GetComponent<Bullet>().SetOwner(this.gameObject);

        //Retrieve rigidbody
        var tempRB = tempObj.GetComponent<Rigidbody>();

        //Launch
        tempRB.AddForce(transform.forward * launchForce, launchForceMode);

        //Clean up
        Destroy(tempObj, bulletLifetime);
    }
}