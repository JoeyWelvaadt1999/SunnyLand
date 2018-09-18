using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseHandler : MonoBehaviour {

    public Text _loseText;

    private void Start()
    {
        PlayerHealth.OnDeathEvent += ShowText;

    }

    void ShowText()
    {
        _loseText.text = "You Lose!";
        PlayerHealth.OnDeathEvent -= ShowText;
    }
}
