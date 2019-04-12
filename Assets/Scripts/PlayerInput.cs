using UnityEngine;

public class PlayerInput : MonoBehaviour {

	[HideInInspector] public Vector2 axis;
	[HideInInspector] public bool isShooting;	
	[HideInInspector] public bool isDashing;
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public bool selectNextWeapon;
    [HideInInspector] public bool selectPrevWeapon;

    [SerializeField] bool invertHorizontal = false;
	[SerializeField] bool invertVertical = false;
	[SerializeField] bool raw = false;
	[SerializeField] KeyCode shootButton = KeyCode.Space;
	[SerializeField] KeyCode dashButton = KeyCode.Mouse1;
    [SerializeField] KeyCode sprintButton = KeyCode.LeftShift;
    [SerializeField] KeyCode nextWeaponButton = KeyCode.Mouse1;
    [SerializeField] KeyCode prevWeaponButton = KeyCode.Mouse0;


    void Update ()
    {
        SetAxes();
        SetShoot();
        SetDash();
        SetSprint();
        SetWeaponSwaps();
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
        if (Input.GetKey(shootButton))
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
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
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

    public void SetWeaponSwaps()
    {
        if (Input.GetKeyDown(nextWeaponButton))
        {
            selectNextWeapon = true;
        }
        else if (Input.GetKeyDown(prevWeaponButton))
        {
            selectPrevWeapon = true;
        }
        else
        {
            selectNextWeapon = false;
            selectPrevWeapon = false;
        }
    }
}
