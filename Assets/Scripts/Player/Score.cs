using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text _scoreText;
    private int _score;

    // Use this for initialization
    void Start()
    {
        Collectible.OnHitEvent += UpdateScore;
        PlayerHealth.OnDeathEvent += Unsubscribe;

        _score = 0;
        SetScoreUI();
    }

    void UpdateScore()
    {
        _score++;
        SetScoreUI();
    }


    void Unsubscribe()
    {
        Collectible.OnHitEvent -= UpdateScore;
        PlayerHealth.OnDeathEvent -= Unsubscribe;
    }

    void SetScoreUI()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
