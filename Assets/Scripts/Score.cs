using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int _score;

	// Use this for initialization
	void Start () {
		
	}

    void UpdateScore()
    {
        _score++;
    }

    ///TO DO
    ///subscribe to Collectible delegate
    ///do something in score
    ///display it [in log at least]
}
