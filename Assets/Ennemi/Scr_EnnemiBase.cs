using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnnemiBase : MonoBehaviour
{

    public GameObject particlesDeath;


    [Header("RayCast")]
    bool onGround = false;
    private RaycastHit hitInfo;
    [Range(0, 100)]
    public float rayLength = 0.5f;

    private void OnEnable()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<Scr_Player_Base>().dead)
            {
                other.GetComponent<Scr_Player_Base>().TakesDamages(transform.forward);
            }
           
        }


    }

    private void Update()
    {
        DetectCollisions();
        if (!onGround)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }


    public void Dead()
    {
        Debug.Log("Ennemi : " + gameObject + " mort");
        FindObjectOfType<Scr_ScoreManager>().GainScore();
        Destroy(gameObject);
        Instantiate(particlesDeath, transform.position, new Quaternion(0,90,90,0));
        FindObjectOfType<Scr_AudioManager>().Play("Ejection");

    }

    void DetectCollisions()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hitInfo, rayLength))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            onGround = true;
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.green);
            onGround = false;
        }
    }


    private void OnDisable()
    {

    }


}
