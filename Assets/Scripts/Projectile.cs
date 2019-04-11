using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	private Rigidbody rb;
	[SerializeField] float mass = 0.5f;
	[SerializeField] bool affectedByGravity = true;

	float startTime;

	void Awake()
	{
		//Cache rb
		rb = GetComponent<Rigidbody>();

		//Set projectile properties
		rb.useGravity = affectedByGravity;
		rb.mass = mass;
	}
}