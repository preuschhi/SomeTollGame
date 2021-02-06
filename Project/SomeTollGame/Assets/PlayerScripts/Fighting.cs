using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    
   public Transform shootingPoint;
   public GameObject bulletPrefab;

   public float shootingForce = 20f;
    
   void Update(){

       if (Input.GetButtonDown("Fire1")){
           Shoot();
       }

   }     
   
    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody2D rbBullet =  bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(shootingPoint.up * shootingForce, ForceMode2D.Impulse);
    }

}
