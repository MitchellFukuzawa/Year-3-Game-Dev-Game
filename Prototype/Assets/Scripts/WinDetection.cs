using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetection : MonoBehaviour {

    // Attach to the player.

    private void OnTriggerEnter(Collider other)
    {
        // if this player collides with the bullet
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
