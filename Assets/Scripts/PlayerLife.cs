using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{   
    private Rigidbody2D rb;
    private Animator anim;

    LivesCounter livesCounter;
    [SerializeField] private GameObject LivesCounterUI;

    private void Awake()
    {
        livesCounter = LivesCounterUI.GetComponent<LivesCounter>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Enemy")
        {
            // KillDave();
            livesCounter.RemoveLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // KillDave();
            livesCounter.RemoveLife();
        }
    }

    public void KillDave()
    {
        // Stops Dave from moving
        rb.bodyType = RigidbodyType2D.Static;

        // Starts Death animation
        anim.SetTrigger("death");
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
