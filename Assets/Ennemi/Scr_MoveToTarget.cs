using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scr_MoveToTarget : MonoBehaviour
{
    public NavMeshAgent nmAgent;

    public GameObject cible;

    public Scr_TakesDamages baseEnnemi;
    private void Start()
    {
        baseEnnemi = GetComponent<Scr_TakesDamages>();
        cible = GameObject.FindGameObjectsWithTag("Player")[0];
        Debug.Log("Ennemi Cible : " + cible);
    }

    void Update()
    { 
        if (!baseEnnemi.stun && nmAgent.isActiveAndEnabled && !cible.GetComponent<Scr_Player_Base>().dead)
        {
            nmAgent.SetDestination(cible.transform.position);
        }
        
        
    }
}
