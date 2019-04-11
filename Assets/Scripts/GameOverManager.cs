using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // reference to the player's health
    public Player m_playerHealth;
    // how long it takes once the player dies for the game to restart
    public float m_restartDelay = 5.0f;

    // reference to the HUD animator
    private Animator m_anim;
    // timer for the restart delay
    private float m_restartTimer;

    private void Awake()
    {
        // gets the animator component from the HUD object
        m_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // checks if the player has died
        if (m_playerHealth.m_currentHealth <= 0)
        {
            // triggers the transition to the game over state
            m_anim.SetTrigger("GameOver");

            // increments the timer by the frame time
            m_restartTimer += Time.deltaTime;
            // checks if the timer is greater than or equal to the restart delay
            if (m_restartTimer >= m_restartDelay)
            {
                // restarts the game
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}