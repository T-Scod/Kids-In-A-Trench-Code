﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	[Header("Settings")]
    [SerializeField] bool autoFire = false;
	[SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] float launchForce = 500;
    [SerializeField] ForceMode launchForceMode = ForceMode.Force;
    [SerializeField] float timeBetweenShots = 0.15f;
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
        // Debug.Log("Gun firing bullet");
        //Regulate shots
        if (timeSinceLastFired < timeBetweenShots && !autoFire)
            return;

        // resets the timer
        timeSinceLastFired = 0f;

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
            gunSounds.PlayOnce();
        }
    }
}