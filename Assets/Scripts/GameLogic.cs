using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private static int score = 0;
    [SerializeField] private Text scoreText;

    public static bool cup = false;
    public Tilemap Stuff;
    
    private Sprite currentTile;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        
       
        if (collision.gameObject.tag == "Pickups")
        {

            currentTile = Stuff.GetSprite(Stuff.WorldToCell(gameObject.transform.position));
            Debug.Log(currentTile.name);

            // Message to Karan Bhaiya
            // See if you can access the delete tile function of tile pallete from within the screen itself instead of setting the position to NULL

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

            if(currentTile.name == "dave-tiles_17")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                score += 200;
            }

            if(currentTile.name == "dave-tiles_53")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                score += 300;
            }

            if(currentTile.name == "dave-tiles_22")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                score += 500;
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

        else if (collision.gameObject.tag == "Pickups")
        {
            // Destroy(gameObject.Dave);
        }
    }
    
}
