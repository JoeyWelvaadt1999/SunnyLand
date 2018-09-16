using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningHandler : MonoBehaviour {
    
    public Text _winText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYERTAG)
        {
            //show text that you have won and sent event so that player plays final animation
            _winText.text = "YOU WIN!";
        }
    }
}
