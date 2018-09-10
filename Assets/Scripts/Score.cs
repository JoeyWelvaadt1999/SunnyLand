using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int _score;

	// Use this for initialization
	void Start () {
        Collectible.OnHitEvent += UpdateScore;
        PlayerHealth.OnDeathEvent += Unsubscribe;
	}

    void UpdateScore()
    {
        _score++;
        Debug.Log("Score is " + _score);
    }

    void Unsubscribe()
    {
        Collectible.OnHitEvent -= UpdateScore;
        PlayerHealth.OnDeathEvent -= Unsubscribe;
    }

    
}
