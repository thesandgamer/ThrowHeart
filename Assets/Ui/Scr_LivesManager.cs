using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Scr_LivesManager : MonoBehaviour
{
    public int lifes;
    public int hearth;

    public Scr_Player_Base player;

    [SerializeField] Sprite hearthEmpty;
    [SerializeField] Sprite hearthFull;
    [SerializeField] Sprite hearthLoose;


    public GameObject[] sprites;

    private void OnEnable()
    {
        
        Scr_Hearth.ev_looseLife += LooseLife;
        Scr_Hearth.ev_recoverHeart += RegainHearth;

        Scr_Throw.ev_looseHeart += LooseHearth;

        Scr_Player_Base.ev_PlayerTakesDamages += LooseLife;
        Scr_Player_Base.ev_PlayerDeath += Death;


        Scr_MenuManager.ev_GameStart += GameStart;


    }


    void GameStart()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Scr_Player_Base>();
        if (player!= null)
        {
            lifes = player.lives;
            hearth = player.hearth;
        }
        sprites[0].GetComponent<Image>().sprite = hearthFull;
        sprites[1].GetComponent<Image>().sprite = hearthFull;
        sprites[2].GetComponent<Image>().sprite = hearthFull;

    }

    void LooseLife()
    {
        lifes--;
        hearth--;
        // sprites[lifes].GetComponent<Image>().sprite = hearthLoose;
        GestionLifes();
    }

    void LooseHearth()
    {
       hearth--;
        // sprites[hearth].GetComponent<Image>().sprite = hearthEmpty;
        GestionHearth();

    }

    void RegainHearth()
    {
        //sprites[hearth].GetComponent<Image>().sprite = hearthFull;
        hearth++;
        GestionHearth();



    }

    void Death()
    {
        hearth = 0;
        lifes = 0;
        sprites[0].GetComponent<Image>().sprite = hearthLoose;
        sprites[1].GetComponent<Image>().sprite = hearthLoose;
        sprites[2].GetComponent<Image>().sprite = hearthLoose;
    }

    void GestionHearth()
    {
        switch (hearth)
        {
            case 0:
                if (sprites[0].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[0].GetComponent<Image>().sprite = hearthEmpty;
                }
                if (sprites[1].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[1].GetComponent<Image>().sprite = hearthEmpty;
                } 
                if (sprites[2].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[2].GetComponent<Image>().sprite = hearthEmpty;
                }
            break;

            case 1:
                if (sprites[0].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[0].GetComponent<Image>().sprite = hearthFull;
                }
                if (sprites[1].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[1].GetComponent<Image>().sprite = hearthEmpty;
                }
                if (sprites[2].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[2].GetComponent<Image>().sprite = hearthEmpty;
                }  
            break;

            case 2:
                if (sprites[0].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[0].GetComponent<Image>().sprite = hearthFull;
                }
                if (sprites[1].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[1].GetComponent<Image>().sprite = hearthFull;
                }
                if (sprites[2].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[2].GetComponent<Image>().sprite = hearthEmpty;
                } 
            break;

            case 3:
                if (sprites[0].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[0].GetComponent<Image>().sprite = hearthFull;
                }
                if (sprites[1].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[1].GetComponent<Image>().sprite = hearthFull;
                }
                if (sprites[2].GetComponent<Image>().sprite != hearthLoose)
                {
                    sprites[2].GetComponent<Image>().sprite = hearthFull;
                }              
            break;
        } 
    }  
    void GestionLifes()
    {
        switch (lifes)
        {
            case 0:
                sprites[0].GetComponent<Image>().sprite = hearthLoose;
                sprites[1].GetComponent<Image>().sprite = hearthLoose;
                sprites[2].GetComponent<Image>().sprite = hearthLoose;
            break;

            case 1:
                sprites[1].GetComponent<Image>().sprite = hearthLoose;
            break;

            case 2:
                sprites[2].GetComponent<Image>().sprite = hearthLoose;
            break;

            case 3:

            break;
        } 
    }


    private void OnDisable()
    {
        Scr_Hearth.ev_looseLife -= LooseLife;
        Scr_Hearth.ev_recoverHeart -= RegainHearth;

        Scr_Throw.ev_looseHeart -= LooseHearth;

        Scr_Player_Base.ev_PlayerTakesDamages -= LooseLife;
        Scr_Player_Base.ev_PlayerDeath -= Death;

        Scr_MenuManager.ev_GameStart -= GameStart;
    }





}
