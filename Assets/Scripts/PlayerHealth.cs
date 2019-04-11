using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    Image[] m_heartImages;
    PlayerController pController;
    PlayerShooting pShooter;


    void Awake()
    {
        pController = GetComponent<PlayerController>();
        pShooter = GetComponentInChildren<PlayerShooting>();

        //Why is this needed?
        m_heartImages = FindObjectOfType<PlayerHealthBar>().GetComponentsInChildren<Image>();
    }

    public override void Death()
    {
        pController.enabled = false;
        pShooter.enabled = false;
    }
}