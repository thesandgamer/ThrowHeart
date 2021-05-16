using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textFinal;

    private void OnEnable()
    {
        Scr_MenuManager.ev_GameStart += Setup;
    }

    void Setup()
    {
        score = 0;
        text.text = score.ToString();
        textFinal.text = score.ToString();
    }


    private void Start()
    {
        text.text = score.ToString();
    }


    public void GainScore()
    {
        score++;
        text.text = score.ToString();
        textFinal.text = score.ToString(); 
    }




    private void OnDisable()
    {
        Scr_MenuManager.ev_GameStart -= Setup;
    }



}
