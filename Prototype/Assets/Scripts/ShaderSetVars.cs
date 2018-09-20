using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSetVars : MonoBehaviour {

    public Material mat;
    //public float offset = 10f;
    public AnimationCurve t;
    

    // Update is called once per frame
    void Update()
    {
        //if (offset > 0)

        mat.SetFloat("_offset", t.Evaluate(Time.time));
        //print("<color=red>Eval: " + t.Evaluate(Time.time));

        if (Time.time >= 1)
        {
            mat.SetFloat("_offset", 0);
        }

    }
}
