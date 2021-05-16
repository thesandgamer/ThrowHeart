using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Scr_TakesDamages : MonoBehaviour
{
    Rigidbody rb;
    NavMeshAgent nvAgent;
    public bool stun;
    public int time= 5;

    [Header("Particles")]
    public GameObject pushParticles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        nvAgent = GetComponent<NavMeshAgent>();
    }


    public void TakesDamages(int force,Vector3 direction)
    {
        Debug.Log("Takes Damages");
        stun = true;
        nvAgent.enabled = false;
        rb.AddForce(direction.x * force, 0f, direction.z * force, ForceMode.Impulse);
        Debug.Log("Ejction : " + direction * force);
        StartCoroutine(DeStun());
        Instantiate(pushParticles, transform.position, transform.rotation);

        FindObjectOfType<Scr_AudioManager>().Play("Punch");


    }


    IEnumerator DeStun()
    {
        yield return new WaitForSeconds(time);
        stun = false;
        nvAgent.enabled = true;
        rb.AddForce(Vector3.zero, ForceMode.Impulse);

    }

}
