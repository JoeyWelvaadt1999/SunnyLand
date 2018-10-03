using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score.
/// This class keeps track of the player score and puts it on screen.
/// </summary>
public class Score : MonoBehaviour {

    public Text _scoreText;
    private int _score;

    
	// In this function will everything be initialized and the delegates will be added. 
    void Start()
    {
        
        PlayerHealth.OnDeathEvent += Unsubscribe;

        _score = 0;
        SetScoreUI();
    }

    void UpdateScore()
    {
        _score++;
        SetScoreUI();
    }

	//Here the delegates will be removed so that they cant be called anymore.
    void Unsubscribe()
    {
        
        PlayerHealth.OnDeathEvent -= Unsubscribe;
    }

    void SetScoreUI()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
