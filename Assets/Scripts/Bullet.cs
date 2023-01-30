using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Do not destroy upon 
        if (hitInfo.name == "Dave" || hitInfo.tag == "Interactables")
        {
            // Do nothing
        }

        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
