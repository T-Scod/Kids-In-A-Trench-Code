// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     private Rigidbody rigidbody;
//     private Vector3 velocity;
//     public float m_speed;
//     private float m_speedModifier;

//     private float dashTime;


//     private void Start()
//     {
//         rigidbody = GetComponent<Rigidbody>();
//     }

//     void Update()
//     {
//         if (GetComponent<PlayerInput>().sprint == true)
//         {
//             m_speedModifier = 2f;
//         }
//         else
//         {
//             m_speedModifier = 1f;
//         }

//         velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")).normalized * m_speed * m_speedModifier;

//         if (GetComponent<PlayerInput>().shoot == true)
//             Shoot();
//         if (GetComponent<PlayerInput>().dash == true && dashTime == 0)
//             Dash();
//     }

//     private void FixedUpdate()
//     {
//         rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
//     }

//     void Dash()
//     {
//         float dashTime = 5;
//         if (dashTime > 0)
//         {
//             m_speedModifier = 40f;
//             dashTime--;
//         }
//         if (dashTime == 0)
//             m_speedModifier = 1;
//     }

//     void Shoot()
//     {

//     }
// }