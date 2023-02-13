using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    PlayerMovement playerMovement;
    [SerializeField] private GameObject Dave;

    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Rigidbody2D rb;

    void Awake()
    {
        playerMovement = Dave.GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Do not destroy upon 
        if (hitInfo.name != "Dave" && hitInfo.tag != "Pickups" && hitInfo.tag != "Traps")
        {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);

            // Debug.Log(playerMovement.shotFired);
            // playerMovement.Invoke("destroyedBullet",3);
            // Debug.Log(playerMovement.shotFired);
        }
            
    }
}
