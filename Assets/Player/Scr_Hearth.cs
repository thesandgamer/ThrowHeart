using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Scr_Hearth : MonoBehaviour
{
    public static Action ev_looseLife;
    public static Action ev_recoverHeart;

    public float lifeTime = 20;
    public int  force = 500;

    public GameObject destroyParticles;

    void Start()
    {
        StartCoroutine(LifeTime());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ev_recoverHeart != null) ev_recoverHeart();
            Destroy(gameObject);
        }

        if (other.CompareTag("Ennemi"))
        {
            other.GetComponent<Scr_TakesDamages>().TakesDamages(force,gameObject.transform.forward);
            FindObjectOfType<Scr_FxManager>().ScreenShake();
        }

    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        DestroyHearth();
    }

    public void DestroyHearth()
    {
        if (ev_looseLife != null) ev_looseLife();
        Instantiate(destroyParticles, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
