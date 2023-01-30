using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public static int diamonds;
    public static int pills;
    public static bool cup = false;
    public Tilemap Stuff;
    public Sprite blank;
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
                diamonds = diamonds + 1;
                Debug.Log("diamonds: " + diamonds);
            }

            else if(currentTile.name == "pill")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                pills = pills + 1;
                Debug.Log("pills: " + pills);
            }
            else if(currentTile.name == "cup1")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                cup = true;
                Debug.Log("cup taken");
            }
            else if(currentTile.name == "door")
            {
                if(cup == true)
                {
                    gameObject.transform.position = new Vector3(-6.3f, -3.615f, 0f);
                    //SceneManager.LoadScene(SampleScene,LoadSceneMode.Single);
                }
                
            }

        }
    }
    
}
