using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Spawner : MonoBehaviour
{
    public Transform[] spawPoint;

    public int nbToSpawn;
    public GameObject ennemi;

    public int nbWaves = 5;
    int wave = 1;

    float waveTimer = 20;

    bool active = true;

    private void OnEnable()
    {
        Scr_MenuManager.ev_GameStart += Setup;
        Scr_Player_Base.ev_PlayerDeath += PlayerDead;
    }

    void Setup()
    {
        active = true;
        wave = 1;
        waveTimer = 20;
        SpawnWave();
    }

    void SpawnWave()
    {
        if (active)
        {
            for (int i = 0; i < nbToSpawn; i++)
            {
                Instantiate(ennemi, spawPoint[i].position, spawPoint[i].rotation);
            }
            StartCoroutine(WaitWave());
        }
        
    }

    IEnumerator WaitWave()
    {
        yield return new WaitForSeconds(waveTimer);
        SpawnWave();
        wave++;
        waveTimer--;
    }

    void PlayerDead()
    {
        active = false;
    }

    private void OnDisable()
    {
        Scr_MenuManager.ev_GameStart -= Setup;
        Scr_Player_Base.ev_PlayerDeath -= PlayerDead;
    }



}
