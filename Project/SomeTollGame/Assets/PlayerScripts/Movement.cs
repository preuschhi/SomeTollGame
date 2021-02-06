using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Rigidbody2D rbPlayer;
    public Transform player;
    public Transform playerGunJoint;

    //Getting Needed Compnents
    void Start()
    {
       rbPlayer = GetComponentInChildren<Rigidbody2D>(); 
       if(player == null){
       player = GetComponentInChildren<Transform>();
       }
       if (playerGunJoint == null) {
       playerGunJoint = GetComponentInChildren<Transform> ();
       } 
    }

    //Movingspeed of Player
    public float moveSpeed = 10f;


    Vector2 mousePosition;
    public float mouseAngle;
    


    public float x;
    public float y;
    void FixedUpdate()
    {
        //Getting input for playerMovement
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        //Moving the player
        rbPlayer.velocity = new Vector2(x * moveSpeed, y * moveSpeed);
       
        //Rotating the player
        Vector3 movement = new Vector3(x,y,0);
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, movement);
        Vector3 rotation = lookRotation.eulerAngles;
        player.rotation = Quaternion.Euler(0f, 0f, rotation.z);
        

        //Rotating the shooting pipe
        //Getting the position of the mouse
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(playerGunJoint.position);
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        mouseAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    
         playerGunJoint.rotation = Quaternion.Euler(0, 0, mouseAngle);


    }
} 
