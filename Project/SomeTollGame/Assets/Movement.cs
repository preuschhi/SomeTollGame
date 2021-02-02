using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Rigidbody2D rbPlayer;

    void Start()
    {
       rbPlayer = GetComponent<Rigidbody2D>(); 
    }

    public float moveSpeed = 10f;
    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rbPlayer.velocity = new Vector2(x * moveSpeed, y * moveSpeed );
    
        float xMouse = Input.GetAxis("")
    }
}
