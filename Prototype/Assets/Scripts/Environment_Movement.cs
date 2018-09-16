using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Movement : MonoBehaviour {
    
    /* attach to moveable object
     * set tran
     * 
     * 
     */

    public List<Transform> objectPositions;
    public KeyCode activationButton;
    public float Speed = .1f;
    private Transform startPosition;
    //public IEnumerable movementMode;      // For later use to implement a different lerp method

    private Rigidbody rb;
    private bool start = false;
    public int pos = 0;
    public float t_lerp = 0;
    public bool add = true;        // For lerping up to list.count and back to 0

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = gameObject.transform;
    }

    void FixedUpdate ()
    {
        // Will have to change to suite Makee Makee for now key board events
        if (Input.GetKeyDown(activationButton))
        {
            start = true;
        }

        if (start)
        {
            // update player pos
            gameObject.transform.position = Vector3.Lerp(transform.position, objectPositions[pos].position, t_lerp);

            // timer
            t_lerp += Time.deltaTime * Speed;

            // Check which dir we need to go
            if (pos == objectPositions.Count)
                add = false;


            // if at end change pos num
            if (t_lerp > 1)     // Asks what we want to change pos to
            {
                if (add)
                {
                    t_lerp = 0;
                    pos++;
                }
                else{
                    t_lerp = 0;
                    pos--;
                }
            }

            if(pos == objectPositions.Count)
                start = false;
        }
	}
}
