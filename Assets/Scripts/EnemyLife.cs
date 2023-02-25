using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    // private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float deathDelay = 0.5f;

    [SerializeField] private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   
    }

    private void KillMe()
    {
        // Stops Eobject from moving
        // rb.bodyType = RigidbodyType2D.Static;

        // Starts Death animation and then kills with a delay
        anim.SetTrigger("enemy_death");
        deathSound.Play();
        Destroy(gameObject, deathDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            KillMe();
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Bullet")
        {
            KillMe();
        }
    }
}
