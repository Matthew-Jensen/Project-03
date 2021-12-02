using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private bool collided;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player")
        {
            collided = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0f, 0f, 0f);
        }
    }
}
