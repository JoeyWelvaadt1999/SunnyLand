using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == Constants.PLAYERTAG) {
			PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth> ();
			ph.DecreaseHealthPoints ();
		}
	}
}
