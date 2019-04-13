using UnityEngine;

public class Wasted : MonoBehaviour {

	PlayerHealth player;

	public GameObject[] gameoverObjs;

	void Start()
	{
		SetGameOverActive(false);
	}

	void Update()
	{
		if (!player)
		{
			player = FindObjectOfType<PlayerHealth>();
		}
		else {
			if (player.isDead)
            {
                Cursor.visible = true;
                SetGameOverActive(true);
            }
        }
	}

    private void SetGameOverActive(bool active)
    {
        foreach (var go in gameoverObjs)
        {
            go.SetActive(active);
        }
    }
}
