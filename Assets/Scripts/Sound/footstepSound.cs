using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;       //Sound to play
    bool ismoving;        
    public float walkingspeed;


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
        InvokeRepeating("callFootsteps", 0, walkingspeed);  //les bruits de pas ne peuvent se répéter qu'avec walkingspeed d'intervalle
    }
}