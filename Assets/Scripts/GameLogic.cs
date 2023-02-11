using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private FloatSO scoreSO;

    public static bool cup = false;
    public Tilemap Stuff;
    
    private Sprite currentTile;

    private void Awake()
    {
        // Reset at the start of game
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            scoreSO.Value = 0;
        }
        // Initialize the score at beginning of each level
        scoreText.text = "Score: " + scoreSO.Value;
    }

    // Loads the next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
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
                scoreSO.Value += 100;
            }

            if(currentTile.name == "pill")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                scoreSO.Value += 50;
            }

            if(currentTile.name == "dave-tiles_51")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                scoreSO.Value += 150;
            }

            if(currentTile.name == "dave-tiles_17")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                scoreSO.Value += 200;
            }

            if(currentTile.name == "dave-tiles_53")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                scoreSO.Value += 300;
            }

            if(currentTile.name == "dave-tiles_22")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                scoreSO.Value += 500;
            }

            if(currentTile.name == "cup1")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                cup = true;
                scoreSO.Value += 1000;
                Debug.Log("cup taken");
            }
            if(currentTile.name == "door")
            {
                if(cup == true)
                {
                    gameObject.transform.position = new Vector3(-6.3f, -3.615f, 0f);
                    //SceneManager.LoadScene(SampleScene,LoadSceneMode.Single);
                    // SceneManager.LoadScene(1);
                    LoadNextScene();
                }
                
            }
            
            scoreText.text = "Score: " + scoreSO.Value;

        }

        else if (collision.gameObject.tag == "Traps")
        {
            // Kill Dave
            // Destroy(gameObject.Dave);
        }
    }
    
}
