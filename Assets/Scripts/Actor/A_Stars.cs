using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Stars : MonoBehaviour
{
    [SerializeField] private List<string> _starPowers = new List<string>();

    public bool LookingUp;


    public void AddStarPower(StarDataObject data)
    {
        _starPowers.Add(data.id);

    }


    private void Update()
    {
        if (!Actor.i.paused)
        {
            LookUpCheck();
        }
    }

    private void LookUpCheck()
    {
        //is the right stick pushing up?
        if (Actor.i.input.RSY > 0.3f)
        {
            LookingUp = true;
        }
        else
        {
            LookingUp = false;
        }
    }
}
