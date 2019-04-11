using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    // health when the level starts
    public int m_startingHealth = 3;
    // current health of the player
    public int m_currentHealth;

    private Image[] m_heartImages;
    // reference to the movement script
    private PlayerMovement m_playerMovement;
    // reference to the shooting script
    private PlayerShooting m_playerShooting;
    // determines if the player is dead
    private bool m_isDead;
    // determines if the player is damaged
    private bool m_damaged;

    private void Awake()
    {
        // gets the components from the object
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerShooting = GetComponentInChildren<PlayerShooting>();
        // sets the current health to the starting health
        m_currentHealth = m_startingHealth;
        m_heartImages = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Image>();
    }

    // reduces the health by the amount
    public void TakeDamage(int amount)
    {
        // decrements the current health by the amount
        m_currentHealth -= amount;
        m_heartImages[m_currentHealth].color = Color.black;

        // checks if the health is less than 0 or the player is dead
        if(m_currentHealth <= 0 && !m_isDead)
        {
            // sets the player to death
            Death();
        }
    }

    // sets the player to dead
    void Death()
    {
        // sets the dead status to true
        m_isDead = true;

        // disables player movement
        m_playerMovement.enabled = false;
        // disables player shooting
        m_playerShooting.enabled = false;
    }
}