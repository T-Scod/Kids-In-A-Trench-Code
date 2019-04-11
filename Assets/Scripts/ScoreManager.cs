using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    // score of the class
    public static int m_score;

    // reference to the score text
    private Text m_text;

    private void Awake()
    {
        // gets the score text
        m_text = GetComponent<Text>();
        // sets the score to 0
        m_score = 0;
    }

    private void Update()
    {
        // sets the score text to the score
        m_text.text = "Score: " + m_score;
    }
}