using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Scr_Camera : MonoBehaviour
{
    public GameObject cible;

    public Vector3 offset;

    public Vector3 acceptance;

    private void OnEnable()
    {
        Scr_MenuManager.ev_GameStart += SetupCamera;
    }

    void SetupCamera()
    {
        cible = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    private void Update()
    {
        if (cible != null)
        {
            Vector3 posCible = new Vector3(cible.transform.position.x, transform.position.y, cible.transform.position.z);
            transform.position = new Vector3(posCible.x + offset.x, posCible.y, posCible.z + offset.z);
        }
       
    }

    private void OnDisable()
    {
        Scr_MenuManager.ev_GameStart -= SetupCamera;
    }


}
