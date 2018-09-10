using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetection : MonoBehaviour {

    // Attach to the player.

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player_1 Bullet") // This tells us whoes bullet killed this gameobject
        {
            // Add point or take away life from this player (aka gameobject)
            // Then destroy the player, or destory and respawn the player

            
        }

        // if this player collides with the bullet
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
