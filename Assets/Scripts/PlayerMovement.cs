using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement speed
    public float m_speed = 6.0f;
    //movement speed multiplier
    private float m_speedModifier;
    // movement direction
    private Vector3 m_movement;
    // player rigidbody
    private Rigidbody m_playerRb;
    // length of the camera ray
    private float m_camRayLength = 100.0f;

    public GameObject m_crosshair;
    private void Awake()
    {
        m_playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(new Vector3(m_crosshair.transform.position.x, transform.position.y, m_crosshair.transform.position.z));
        // gets the horizontal movement value
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        // gets the vertical movement value
        float moveVertical = Input.GetAxisRaw("Vertical");

        // moves, turns and animates the player
        Move(moveHorizontal, moveVertical);
    }

    // moves the player
    private void Move(float h, float v)
    {
        // sets the movement direction to the horizontal and vertical components
        m_movement.Set(h, 0.0f, v);
        // converts the movement vector to real time movement
        m_movement = m_movement.normalized * m_speed * Time.deltaTime;
        // moves the rigidbody to the current position plus the movement
        m_playerRb.MovePosition(transform.position + m_movement);
    }
}