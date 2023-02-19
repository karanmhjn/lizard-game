using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{   
    [SerializeField] private GameObject Dave;
    [SerializeField] private GameObject startingDavePoint;
    [SerializeField] private GameObject startingCameraPoint;
    [SerializeField] private GameObject camera;

    private Rigidbody2D rb;
    private Animator anim;
    public bool cheatDeath;
    public bool neverDeath;

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
        if ((collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Enemy")&& !neverDeath)
        {
            // Kill Dave and go back to initial state
            KillDave();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !neverDeath)
        {
            KillDave();
        }
    }

    private void KillDave()
    {
        if (!cheatDeath)
        {
            livesCounter.RemoveLife();
        }
        

        // Stops Dave from moving
        rb.bodyType = RigidbodyType2D.Static;

        // Starts Death animation
        anim.SetTrigger("death");

        Invoke("ResetDave", 1);
    }

    private void ResetDave()
    {
        // Sets Dave back into idle state
        anim.SetTrigger("reset");

        // Resets position of both Dave and the camera
        transform.position = startingDavePoint.transform.position;
        transform.rotation = startingDavePoint.transform.rotation;
        
        camera.transform.position = startingCameraPoint.transform.position;
        camera.transform.rotation = startingCameraPoint.transform.rotation;

        // Resumes Dave's movement
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    
    public void GameOver()
    {
        // Stops Dave from moving
        rb.bodyType = RigidbodyType2D.Static;

        Invoke("Restart",1);
    }

    private void Restart()
    {
        SceneManager.LoadScene("Over Screen");
    }
}
