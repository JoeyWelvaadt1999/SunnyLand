using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text _scoreText;
    private int _score;

	// Use this for initialization
	void Start () {
        Collectible.OnHitEvent += UpdateScore;
        PlayerHealth.OnDeathEvent += Unsubscribe;

        _score = 0;
	}

    void UpdateScore()
    {
        _score++;
        _scoreText.text = "Score: " + _score.ToString();
    }


    void Unsubscribe()
    {
        Collectible.OnHitEvent -= UpdateScore;
        PlayerHealth.OnDeathEvent -= Unsubscribe;
    }

    
}
