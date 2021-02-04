using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Rigidbody2D rbPlayer;
    public Transform playerGunJoint;

    void Start()
    {
       rbPlayer = GetComponentInChildren<Rigidbody2D>(); 
       if (playerGunJoint == null) {
       playerGunJoint = GetComponentInChildren<Transform> ();
       } 
    }


    public float moveSpeed = 10f;
    public Vector2 mousePosition;
    public float mouseAngle;
    public float roationSpeed = 10f;

    public Camera cam;
    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        rbPlayer.velocity = new Vector2(x * moveSpeed, y * moveSpeed);


        
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(playerGunJoint.localPosition);
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        mouseAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    
         playerGunJoint.rotation = Quaternion.Euler(0, 0, mouseAngle);


    }
} 
