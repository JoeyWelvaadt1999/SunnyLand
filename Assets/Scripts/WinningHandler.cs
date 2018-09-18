using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningHandler : MonoBehaviour {
    
    public Text _winText;
    public delegate void WonTheGame();
    public static event WonTheGame WonTheGameEvent;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYERTAG)
        {
            _winText.text = "YOU WIN!";
             WonTheGameEvent();
        }
    }
}
