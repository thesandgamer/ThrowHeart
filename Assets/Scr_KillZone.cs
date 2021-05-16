using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Scr_KillZone : MonoBehaviour
{
    public static Action playerDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerDead != null) playerDead();
        }
        if (other.CompareTag("Ennemi"))
        {
            other.GetComponent<Scr_EnnemiBase>().Dead();
        }
        if (other.GetComponent<Scr_Hearth>())
        {
            other.GetComponent<Scr_Hearth>().DestroyHearth();
        }


    }

}
