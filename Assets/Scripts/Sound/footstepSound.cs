using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;       //Sound to play
    bool ismoving;
    public float walkspeed;

    void Update()
    {
        ismoving = true;           //TO DO : Améliorer les conditions sur ismoving
    }

    void callFootsteps ()
    {
    if (ismoving == true) { 
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }

    void Start()
    {
        InvokeRepeating("callFootsteps", 0, walkspeed);  //les bruits de pas ne peuvent se répéter qu'avec walkingspeed d'intervalle
    }
}