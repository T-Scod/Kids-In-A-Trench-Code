using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public enum FireMode
    {
        Single,
        Burst,
        Auto
    }

	[Header("Settings")]
    [SerializeField] FireMode fireMode = FireMode.Auto;
	[SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] float launchForce = 750;
    [SerializeField] ForceMode launchForceMode = ForceMode.Force;
    [SerializeField] float timeBetweenShots = 0.3f;
    [SerializeField] float bulletLifetime = 3f;

	[Header("Audio")]
	[SerializeField] RandomAudioPlayer gunSounds;

    [Header("Particles")]
    [SerializeField] ParticleSystem particles;

	//Privates
	GameObject owner;
	float timeSinceLastFired;

	public void SetOwner(GameObject parent)	//It is the PlayerShooter's responsibility to own this gun
	{
		this.owner = parent;
	}

    public void Fire()
    {
        //Regulate shots
        if (Time.time-timeSinceLastFired < timeBetweenShots)
        {
            //Can shoot
            return;
        }

        // resets the timer
        timeSinceLastFired = Time.time;

        PlayGunSound();

        //Instantiate
        var tempObj = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

        //Set the bullet's owner to prevent self harm
        tempObj.GetComponent<Bullet>().SetOwner(owner);

        //Retrieve rigidbody
        var tempRB = tempObj.GetComponent<Rigidbody>();

        //Launch
        tempRB.AddForce(transform.forward * launchForce, launchForceMode);

        //Clean up
        Destroy(tempObj, bulletLifetime);
    }

    void PlayGunSound()
    {
        //Play gun sound
        if (gunSounds != null)
        {
            Debug.Log("Player gun sound");
            gunSounds.PlayOnce();
        }
    }
}
