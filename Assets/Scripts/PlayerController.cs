using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;

    PlayerInput input;
    PlayerShooting shooter;
    Transform crossHair;
    Rigidbody rb;

    [HideInInspector] public Vector3 movement;  //Can be accessed through script if needed

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        shooter = GetComponent<PlayerShooting>();
        crossHair = FindObjectOfType<Crosshair>().transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControlLook();
        ControlMovement();
        ControlShooting();
        ControlWeaponSwapping();
    }

    void ControlWeaponSwapping()
    {
        if (input.selectNextWeapon) {
       		Debug.Log("next weapon");
            shooter.NextGun();
        }
        if (input.selectPrevWeapon) {
            Debug.Log("prev weapon");
            shooter.PrevGun();
        }
    }

    void FixedUpdate()
    {
        DoMovement();
    }

    void ControlLook()
    {
        transform.LookAt(new Vector3(crossHair.position.x, transform.position.y, crossHair.position.z));
    } 

    void ControlShooting()
    {
        if (input.isShooting)
        {
            Debug.Log("Controller calls Shooter Shoot");
            shooter.Shoot();
        }
    }

    void ControlMovement()
    {
        var xMotion = input.axis.x * speed * Time.deltaTime;
        var zMotion = input.axis.y * speed * Time.deltaTime;
        movement.Set(xMotion, 0, zMotion);
    }

    void DoMovement()
    {
        rb.MovePosition(transform.position + movement);
    }
}