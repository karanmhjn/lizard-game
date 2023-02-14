using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = -20f;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Do not destroy upon 
        if (hitInfo.tag != "Enemy" && hitInfo.tag != "Pickups" && hitInfo.tag != "Traps")
        {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
            
    }
}
