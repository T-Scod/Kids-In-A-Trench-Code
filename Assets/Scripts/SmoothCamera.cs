using UnityEngine;

public class SmoothCamera : MonoBehaviour 
{
	//Follow the player but not it's rotation

	[SerializeField] float lerp = 0.125f;
	[SerializeField] Vector3 offset;
	PlayerHealth player;		//A player will always have health. Use this to find the player

	void Update()
	{
		if (player == null)
		{
			player = FindObjectOfType<PlayerHealth>();
		}
	}

	void LateUpdate()
	{
		Vector3 desiredPosition = player.transform.position + offset;
		Vector3 lerpedPosition = Vector3.Lerp(player.transform.position, desiredPosition, lerp);
		transform.position = lerpedPosition;
	}

}
