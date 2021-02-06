using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public Rigidbody2D enemy;
    public Rigidbody2D player;

    public float currentDistToPlayer;
    public float maxDistToPlayer = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetDisToPlayer();

        TurnToPlayer();
    }

    void GetDisToPlayer(){
        currentDistToPlayer = Vector3.Distance(player.transform.position, enemy.transform.position);
    }
    void TurnToPlayer(){
        if (currentDistToPlayer < maxDistToPlayer){
            Vector3 relativPosition = player.transform.position - enemy.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, relativPosition);
            Vector3 rotation = lookRotation.eulerAngles;
            enemy.transform.rotation = Quaternion.Euler(0f,0f, rotation.z);
        }
    }
}
