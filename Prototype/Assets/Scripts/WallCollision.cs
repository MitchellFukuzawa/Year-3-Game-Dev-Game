using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        //print("COL: " + other.gameObject.name);

        other.gameObject.SetActive(false);
    }
}
