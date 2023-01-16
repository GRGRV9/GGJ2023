using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrbStash : MonoBehaviour
{
    public Image FirstOrb;
    public Image SecondOrb;
    public Image ThirdOrb;
    public Sprite FireOrb;
    public Sprite IceOrb;
    public Sprite EarthOrb;
    public OrbStash orbStash;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (orbStash.orbStash[0] == "Fire")
        {
            FirstOrb.sprite = FireOrb;
        }
        else if (orbStash.orbStash[0] == "Ice")
        {
            FirstOrb.sprite = IceOrb;
        }
        else if (orbStash.orbStash[0] == "Earth")
        {
            FirstOrb.sprite = EarthOrb;
        }

        if (orbStash.orbStash[1] == "Fire")
        {
            SecondOrb.sprite = FireOrb;
        }
        else if (orbStash.orbStash[1] == "Ice")
        {
            SecondOrb.sprite = IceOrb;
        }
        else if (orbStash.orbStash[1] == "Earth")
        {
            SecondOrb.sprite = EarthOrb;
        }

        if (orbStash.orbStash[2] == "Fire")
        {
            ThirdOrb.sprite = FireOrb;
        }
        else if (orbStash.orbStash[2] == "Ice")
        {
            ThirdOrb.sprite = IceOrb;
        }
        else if (orbStash.orbStash[2] == "Earth")
        {
            ThirdOrb.sprite = EarthOrb;
        }
    }
}
