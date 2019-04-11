using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    PlayerInput input;
    PlayerShooting shooter;
    CharacterController cc;
    Transform crossHair;
    Rigidbody rb;

    [HideInInspector] public Vector3 movement;  //Can be accessed through script if needed

    private void Start()
    {
        cc = GetComponent<CharacterController>();
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