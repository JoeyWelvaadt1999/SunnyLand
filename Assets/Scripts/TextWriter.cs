using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour {

    private float _writingPause = .03f;

    private Text _tutorialText;
    private string _message;

	// Use this for initialization
	void Start () {
        _tutorialText = GetComponent<Text>();
        _message = Constants.TUTORIALTEXT;
        _tutorialText.text = "";
        StartCoroutine(TypeText());
	}
	
    IEnumerator TypeText()
    {
        foreach (char letter in _message.ToCharArray())
        {
            _tutorialText.text += letter;
            yield return new WaitForSeconds(_writingPause);
            Destroy(gameObject, 15);
        }
    }
}
