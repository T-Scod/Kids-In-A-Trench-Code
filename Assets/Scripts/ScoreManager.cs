using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    // score of the class
    public static int score { get; set; }

    // reference to the score text
    private Text m_text;

    private void Awake()
    {
        // gets the score text
        m_text = GetComponent<Text>();
        // sets the score to 0
        score = 0;
    }

    private void Update()
    {
        // sets the score text to the score
        m_text.text = "Score: " + score;
    }
}