using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Scr_Player_Base : MonoBehaviour
{
    public int hearth = 3;
    public int lives;

    Rigidbody rb;

    public static Action ev_PlayerTakesDamages;
    public static Action ev_PlayerDeath;
    

    bool invincible = false;
    public float incincibleTime = 5;

    public bool dead = false;

    [Header("Particles")]
    public GameObject pushParticles;
    public GameObject deadParticles;

    private void OnEnable()
    {
        Scr_Hearth.ev_looseLife += LooseLife;
        Scr_Hearth.ev_recoverHeart += RegainHearth;
        Scr_Throw.ev_looseHeart += LooseHearth;

        Scr_KillZone.playerDead += Dead;

        Scr_MenuManager.ev_GameStart += Setup;
    }

    void Setup()
    {
        lives = 3;
        lives = hearth;
    }

    void Start()
    {
        lives = hearth;
        rb = GetComponent<Rigidbody>();
    }



    void RegainHearth()
    {
        if(hearth<lives)
        {
            hearth++;
        }
        
    }

    void LooseHearth()
    {
        hearth--;
    }

    void LooseLife()
    {
        if (lives - 1 != 0)
        {
            lives--;
            hearth--;
        }
        else if (lives - 1 == 0)
        {
            lives--;
            hearth--;
            Dead();
        }
    }
    


    public void TakesDamages(Vector3 direction)
    {
        if(!invincible)
        {
            Debug.Log("Takes Damages");
            Instantiate(pushParticles, transform.position, transform.rotation);
            rb.AddForce(direction.x * 20, 0f, direction.z * 20, ForceMode.Impulse);
            FindObjectOfType<Scr_AudioManager>().Play("Punch");
            if (lives - 1 != 0)
            {
                lives--;
                hearth--;
                if (ev_PlayerTakesDamages != null) ev_PlayerTakesDamages();
                invincible = true;
                StartCoroutine(ResetInvinbility());
                FindObjectOfType<Scr_FxManager>().ScreenShake();
            }
            else if (lives-1 == 0)
            {
                lives--;
                hearth--;
                Dead();
            }
           
           
        }

    }

    void Dead()
    {
        Debug.Log("Player : " + gameObject + " mort");
        if (ev_PlayerDeath != null) ev_PlayerDeath();
        lives = 0;
        hearth = 0;
        dead = true;
        Instantiate(deadParticles, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    IEnumerator ResetInvinbility()
    {
        yield return new WaitForSeconds(incincibleTime);
        invincible = false;
    }



    private void OnDisable()
    {
        Scr_Hearth.ev_looseLife -= LooseLife;
        Scr_Hearth.ev_recoverHeart -= RegainHearth;
        Scr_Throw.ev_looseHeart -= LooseHearth;

        Scr_KillZone.playerDead -= Dead;

        Scr_MenuManager.ev_GameStart -= Setup;

    }
}
