using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	[SerializeField] float moveSpeed = 0.3f;

	CharacterController charController;
	PlayerInput input;
	PlayerShoot shooter;
	Camera camera;

	void Start()
	{
		charController = GetComponent<CharacterController>();
		input = GetComponent<PlayerInput>();
		shooter = GetComponent<PlayerShoot>();
		camera = Camera.main;
	}

	void Update()
	{
		// var axisInput = playerInput.axis;
		var xAxis = input.axis.x;
		var zAxis = input.axis.y;

		charController.Move(new Vector3(xAxis, 0, zAxis).normalized * moveSpeed);

		if (input.isShooting)
		{
			shooter.Fire(transform);
		}
	}


}
