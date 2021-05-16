using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MenuManager : MonoBehaviour
{
    public static Action ev_GameStart;

    public GameObject main_Menu;
    public GameObject game_Menu;
    public GameObject death_Menu;

    public GameObject player;

    private void OnEnable()
    {
        Scr_Player_Base.ev_PlayerDeath += PlayerDead;
    }

    private void Start()
    {
        game_Menu.SetActive(false);
    }

    public void GameStart()
    {
        main_Menu.SetActive(false);
        game_Menu.SetActive(true);
        GameObject playerStart = GameObject.Find("PlayerStart");
        Debug.Log(playerStart);
        Instantiate(player, playerStart.transform.position, playerStart.transform.rotation);

        if (ev_GameStart != null) ev_GameStart();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        death_Menu.SetActive(false);
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag("Ennemi");
        for (int i =0;i < ennemis.Length; i++)
        {
            Destroy(ennemis[i]);
        } 
        GameObject[] hearth = GameObject.FindGameObjectsWithTag("Hearth");
        for (int i =0;i < hearth.Length; i++)
        {
            Destroy(hearth[i]);
        }
        GameStart();
    }

    void PlayerDead()
    {
        death_Menu.SetActive(true);
        game_Menu.SetActive(false);

    }

    private void OnDisable()
    {
        Scr_Player_Base.ev_PlayerDeath -= PlayerDead;
    }


}
