using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	[SerializeField] Projectile projectile;
	[SerializeField] float force = 10f;
	[SerializeField] ForceMode forceMode = ForceMode.Impulse;
	[SerializeField] float lifetime = 1f;

	//Caches
	Player player;

	void Start()
	{
		player = GetComponent<Player>();
 	}

	public void Fire(Transform startPosition, Transform targetPos)
    {
        var shootDirection = targetPos.position - startPosition.position;
        var shootForce = shootDirection * force;

        Launch(startPosition, shootForce);
    }

    public void Fire(Transform playerTransform)
	{
		var shootDirection = playerTransform.rotation.eulerAngles.normalized;
		var shootForce = shootDirection * force;

		Launch(playerTransform, shootForce);
	}
	
    private void Launch(Transform startPosition, Vector3 shootForce)
    {
        //Create
        var newProjectile = Instantiate(projectile, startPosition.position, startPosition.rotation);

        //Launch
        newProjectile.GetComponent<Rigidbody>().AddForce(shootForce, forceMode);

        //Auto destroy
		Destroy(newProjectile, lifetime);
    }
}
