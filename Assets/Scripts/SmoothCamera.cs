using System.Collections;
using UnityEngine;

public class SmoothCamera : MonoBehaviour 
{
	//Track the player but not it's rotation
	[SerializeField] Vector3 offset = new Vector3(0, 25, -10);
	[SerializeField][Range(0.1f, 1f)] float lerp = 0.4f;
	[SerializeField] bool lookAtPlayer = false;
	[SerializeField] float orientTime = 2f;

	GameObject player;
	bool playerFound = false;

	void Update()
	{
		if (!playerFound) {
			//Search for player until something is found
			player = FindObjectOfType<PlayerHealth>().gameObject;	//Player will always have a PlayerHealth component
			if (player != null)
			{
				playerFound = true;	//Player has been found, stop searching and start tracking
				StartCoroutine(Reorient()); 	//Do initial orientation
			}
		}
		else {
			if (lookAtPlayer)
            {
                LookAtPlayer();
            }
        }
	}
    void LateUpdate()
	{
		Vector3 desiredPosition = player.transform.position + offset;
		Vector3 lerpedPosition = Vector3.Lerp(transform.position, desiredPosition, lerp);
		transform.position = lerpedPosition;
	}

    IEnumerator Reorient()
    {
		var startTime = Time.time;
		while (Time.time - startTime < orientTime)
		{
			LookAtPlayer();
			yield return null;
		}
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player.transform.position, Vector3.forward);
    }
}
