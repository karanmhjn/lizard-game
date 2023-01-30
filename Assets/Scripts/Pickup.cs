using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private static int score = 0;
    [SerializeField] private Text scoreText;

    public static bool cup = false;
    public Tilemap Stuff;
    
    private Sprite currentTile;
    void OnTriggerStay2D(Collider2D collision)
    {
        
       
        if (collision.gameObject.tag == "Interactables")
        {
            // Debug.Log("hey");
            currentTile = Stuff.GetSprite(Stuff.WorldToCell(gameObject.transform.position));
            // Debug.Log(currentTile.name);
            if(currentTile.name == "diamond")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                score += 100;
            }

            if(currentTile.name == "pill")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                score += 50;
            }

            if(currentTile.name == "dave-tiles_51")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                score += 150;
            }

            if(currentTile.name == "cup1")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                cup = true;
                score += 1000;
                Debug.Log("cup taken");
            }
            if(currentTile.name == "door")
            {
                if(cup == true)
                {
                    gameObject.transform.position = new Vector3(-6.3f, -3.615f, 0f);
                    //SceneManager.LoadScene(SampleScene,LoadSceneMode.Single);
                    SceneManager.LoadScene(1);
                }
                
            }

            scoreText.text = "Score: " + score;

        }
    }
    
}
