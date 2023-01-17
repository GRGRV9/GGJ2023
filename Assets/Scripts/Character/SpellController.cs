using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private OrbStash orbStash;
    private Animator animator;

    void Start()
    {
        orbStash = gameObject.GetComponent<OrbStash>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            InvokeSpell();
        }
    }

    void InvokeSpell()
    {
        animator.CrossFade("spellcast", 0.01f);
        int fireOrbsCount = 0;
        int iceOrbsCount = 0;
        int earthOrbsCount = 0;

        animator.SetBool ("isCasting", true);
        foreach (var item in orbStash.orbStash)
        {
            if (item=="Fire")
            {
                fireOrbsCount++;
            }
            else if (item=="Ice")
            {
                iceOrbsCount++;
            }
            else if (item=="Earth")
            {
                earthOrbsCount++;
            }

            //FireSpells
            if (fireOrbsCount==3)
            {
                FireFireFire();
            }
            else if (fireOrbsCount==2 && iceOrbsCount==1)
            {
                FireFireIce();
            }
            else if (fireOrbsCount == 2 && earthOrbsCount == 1)
            {
                FireFireEarth();
            }

            //IceSpells
            if (iceOrbsCount == 3)
            {
                IceIceIce();
            }
            else if (iceOrbsCount == 2 && fireOrbsCount == 1)
            {
                FireIceIce();
            }
            else if (iceOrbsCount == 2 && earthOrbsCount == 1)
            {
                IceIceEarth();
            }

            //EarthSpells
            if (earthOrbsCount == 3)
            {
                EarthEarthEarth();
            }
            else if (earthOrbsCount == 2 && fireOrbsCount == 1)
            {
                FireEarthEarth();
            }
            else if (earthOrbsCount == 2 && iceOrbsCount == 1)
            {
                IceEarthEarth();
            }

            //BalanceSpell
            if (fireOrbsCount==1 && iceOrbsCount==1 && earthOrbsCount==1)
            {
                FireIceEarth();
            }
        }
    }

    void StopSpelling()
    {
        animator.SetBool("isCasting", false);
    }

    void FireFireFire()
    {
        print("FireFireFire");
    }

    void IceIceIce()
    {
        print("IceIceIce");
    }

    void EarthEarthEarth()
    {
        print("EarthEarthEarth");
    }

    void FireFireIce()
    {
        print("FireFireIce");
    }

    void FireFireEarth()
    {
        print("FireFireEarth");
    }

    void FireIceIce()
    {
        print("FireIceIce");
    }

    void IceIceEarth()
    {
        print("IceIceEarth");
    }

    void FireEarthEarth()
    {
        print("FireEarthEarth");
    }

    void IceEarthEarth()
    {
        print("IceEarthEarth");
    }

    void FireIceEarth()
    {
        print("FireIceEarth");
    }
}
