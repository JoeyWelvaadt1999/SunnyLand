using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Disabler.
/// This class disables certain classes on a certain object when this function is called.
/// </summary>
public class Disabler : MonoBehaviour {

    void DisableMovement()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerJump>().enabled = false;
    }
}
