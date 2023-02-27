using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jetBar : MonoBehaviour
{
    private Rigidbody2D rb;
    public Image jetBarInner;
    public Image jetBarOuter;
    private Vector3 currentPos;
    public GameObject player;
    public float jetPackRate;
    private float currentFill;

    [SerializeField] private AudioSource jetSound;

    // Start is called before the first frame update
    void Start()
    {
        currentFill = 1;
        jetBarInner.enabled = false;
        jetBarOuter.enabled = false;
    }
    
    void enableJetBar(Image jetBarInner, Image jetBarOuter)
    {
        if(!jetBarInner.enabled)
        {
            jetBarInner.enabled = true;
            jetBarOuter.enabled = true;
        }
    }
    void disableJetBar(Image jetBarInner, Image jetBarOuter)
    {
        if(jetBarInner.enabled)
        {
            jetBarInner.enabled = false;
            jetBarOuter.enabled = false;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerMovement.hasJet)
        {
            enableJetBar(jetBarInner,jetBarOuter);
            if(PlayerMovement.jetMode)
            {
                if(currentPos != player.transform.position)
                {
                    currentFill -= Time.deltaTime*jetPackRate;
                    jetBarInner.fillAmount = currentFill;
                    currentPos = player.transform.position;
                }
                if(currentFill < 0.01)
                {
                    disableJetBar(jetBarInner,jetBarOuter);
                    PlayerMovement.hasJet = false;
                    PlayerMovement.jetMode = false;
                    jetSound.Pause();
                    rb = player.GetComponent<Rigidbody2D>();
                    rb.gravityScale = 1f;
                }
            }
            
        }
    }
}
