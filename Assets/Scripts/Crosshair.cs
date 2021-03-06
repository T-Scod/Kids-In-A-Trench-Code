﻿using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] float distanceFromFloor = 2f;

	PlayerHealth player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			transform.position = new Vector3(hit.point.x, distanceFromFloor, hit.point.z);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		HideIfPlayerDead();
	}

	private void HideIfPlayerDead()
	{
		//Hide crosshair if player has died
		if (!player)
		{
			player = FindObjectOfType<PlayerHealth>();
		}
		else
		{
			if (player.isDead)
			{
				gameObject.SetActive(false);
			}
		}
	}
}
