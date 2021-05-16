using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Scr_Throw : MonoBehaviour
{

    public static Action ev_looseHeart;

    public GameObject Hearth;
    public GameObject hearthThrow;
    public Transform spawnPoint;

    public float force = 2;

    public float cooldownTime = 2;
    private bool canShoot = true;

    private Scr_Player_Base basePlayer;

    private void Start()
    {
        basePlayer = GetComponent<Scr_Player_Base>();
    }

    public void Shoot()
    {
        if (canShoot && basePlayer.hearth >0)
        {
            Throw();
            canShoot = false;
            StartCoroutine(ResetCooldown());
        }
    }
    
    
    public void Throw()
    {
        Debug.Log("Throw");
        hearthThrow = Instantiate(Hearth, spawnPoint.position,transform.rotation);
        hearthThrow.GetComponent<Rigidbody>().AddForce(transform.forward*force);

        gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * (force/5));
        if (ev_looseHeart != null) ev_looseHeart();

    }
    

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

}
