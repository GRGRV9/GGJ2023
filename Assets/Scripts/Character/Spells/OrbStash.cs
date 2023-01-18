using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbStash : MonoBehaviour
{
    public string[] orbStash = new string[3];

    void Start()
    {
        orbStash[0] = "Fire";
        orbStash[1] = "Fire";
        orbStash[2] = "Fire";
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            orbStash[2] = orbStash[1];
            orbStash[1] = orbStash[0];
            orbStash[0] = "Fire";
        }
        else if (Input.GetKeyDown("w")) 
        {
            orbStash[2] = orbStash[1];
            orbStash[1] = orbStash[0];
            orbStash[0] = "Ice";
        }
        else if (Input.GetKeyDown("e"))
        {
            orbStash[2] = orbStash[1];
            orbStash[1] = orbStash[0];
            orbStash[0] = "Earth";
        }
    }
}
