using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	private Rigidbody rb;
	[SerializeField] float mass = 0.5f;
	[SerializeField] bool affectedByGravity = true;
	[SerializeField] float lifeTime = 3f;
	float startTime = 0.0f;


	void Awake()
	{
		//Cache rb
		rb = GetComponent<Rigidbody>();

		//Set projectile properties
		rb.useGravity = affectedByGravity;
		rb.mass = mass;

	}

	void OnEnable()
	{
		Destroy(this, lifeTime);
	}

	public void Launch(Transform origin, float force, ForceMode forceMode)
	{
		var shootOrigin = origin.position;
		var shootDirection = origin.forward;

		rb.AddForce(origin.forward, forceMode);
	}
}