using UnityEngine;

public class PlayerInput : MonoBehaviour {

	[HideInInspector] public Vector2 axis;
	[HideInInspector] public bool shoot;	
	[HideInInspector] public bool dash;
    [HideInInspector] public bool sprint;

    [SerializeField] bool invertHorizontal = false;
	[SerializeField] bool invertVertical = false;
	[SerializeField] bool raw = false;
	[SerializeField] KeyCode shootButton = KeyCode.Mouse0;
	[SerializeField] KeyCode dashButton = KeyCode.Mouse1;
    [SerializeField] KeyCode sprintButton = KeyCode.LeftShift;


    void Update ()
    {
        SetAxes();
        SetShoot();
        SetDash();
        SetSprint();
    }

    private void SetDash()
    {
        if (Input.GetKeyDown(dashButton))
        {
            isDashing = true;
        }
        else
        {
            isDashing = false;
        }
    }

    private void SetShoot()
    {
        if (Input.GetKeyDown(shootButton))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    private void SetSprint()
    {
        if (Input.GetKey(sprintButton))
        {
            sprint = true;
        }
        else
        {
            sprint = false;
        }
    }

    private void SetAxes()
    {
        if (raw)
        {
            axis.x = invertHorizontal ? -Input.GetAxisRaw("Horizontal") : Input.GetAxisRaw("Horizontal");
            axis.y = invertVertical ? -Input.GetAxisRaw("Vertical") : Input.GetAxisRaw("Vertical");
        }
        else
        {
            axis.x = invertHorizontal ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal");
            axis.y = invertVertical ? -Input.GetAxis("Vertical") : Input.GetAxis("Vertical");
        }
    }
}
