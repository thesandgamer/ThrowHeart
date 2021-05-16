using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Movement : MonoBehaviour
{

    private Vector3 rawInputMovement;
    private Rigidbody rb;

    public float spd = 5;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    Vector2 inputMovement;

    public float horizontalMove = 0f;
    public float verticalMove = 0f;

    Vector3 mousePos;
    Ray mousePos2;

    Vector3 pos;

    Camera cam;


    //
    [Header("Alt Movement")]
    public float moveSpd = 5f;
    public float acceleration = 20;
    public float frictionFactor = 0.9f;
    Vector3 speed;
    Vector2 movement;

    //

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        //Move();
        AltMove();
        Look();

    }


    void Look()
    {

        //Rotate le player
        mousePos2 = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mousePos2.origin, mousePos2.direction * 200, Color.yellow);
        if (Physics.Raycast(mousePos2,out RaycastHit raycastHit))
        {
            pos = raycastHit.point;
            pos = new Vector3(pos.x, 0, pos.z);
        }
        Vector3 lookDir = pos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
       // Debug.Log("Mouse pos : " + mousePos);
        //Debug.Log("Point: " + pos);
        //rb.rotation = Quaternion.Euler(0,angle,0);
        transform.LookAt(new Vector3(pos.x,transform.position.y, pos.z));
    }

    void Move()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * spd;
        verticalMove = Input.GetAxisRaw("Vertical") * spd;

        Vector3 targetVelocity = new Vector3(horizontalMove, rb.velocity.y, verticalMove);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    void AltMove()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 realAcceleration = new Vector3(movement.x * acceleration * Time.deltaTime,0,movement.y * acceleration * Time.deltaTime);
        speed += realAcceleration;
        transform.position += speed;
        speed *= frictionFactor;
    }

}
