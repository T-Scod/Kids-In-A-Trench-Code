using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	[SerializeField] int damage = 1;
	[SerializeField] LayerMask targetLayers;
    [SerializeField] bool destroyOnContact = true;
	[Header("Physics")]
	[SerializeField] float mass = 0.5f;
	[SerializeField] bool affectedByGravity = true;
	[Header("Audio")]
	[SerializeField] RandomAudioPlayer impactSounds;
	[Header("Particles")]
	[SerializeField] ParticleSystem hitParticle;

	protected GameObject m_owner;

	Rigidbody rb;

    void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.mass = mass;
		rb.useGravity = affectedByGravity;
	}

	public void SetOwner(GameObject owner)
	{
		m_owner = owner;
	}

	void OnTriggerEnter(Collider other)
	{
		//Retreive damageable
		Damageable dmg = other.GetComponent<Damageable>();

		//Exit if nothing hit
		if (dmg == null) return;

		//Prevent self harm
		if (dmg.gameObject == m_owner) return;

		//Bounce of an object that is not on target layer
		if ((targetLayers.value & (1 << other.gameObject.layer)) == 0)
		{
			return;
		}

		//Do the damage!
		dmg.TakeDamage(damage);

		//Play a sound
		if (impactSounds != null)
			impactSounds.PlayOnce();

		//Particles!
		if (hitParticle != null) 
			hitParticle.Play();

		//Clean up (gun is responsible for destroying object)
		if (destroyOnContact)
			Destroy(gameObject);
	}

}