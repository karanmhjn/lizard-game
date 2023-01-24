using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public static int diamonds;
    public static int cup;
    public Tilemap Stuff;
    public Sprite blank;
    private Sprite currentTile;
    void OnTriggerStay2D(Collider2D collision)
    {
        
       
        if (collision.gameObject.tag == "Stuff")
        {
            Debug.Log("hey");
            currentTile = Stuff.GetSprite(Stuff.WorldToCell(gameObject.transform.position));
            Debug.Log(currentTile.name);
            if(currentTile.name == "diamond")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                diamonds = diamonds + 1;
            }
            else if(currentTile.name == "cup1")
            {
                Stuff.SetTile (Stuff.WorldToCell(gameObject.transform.position), null);
                cup = cup + 1;
            }
            else if(currentTile.name == "door")
            {
                if(cup > 0)
                {
                    gameObject.transform.position = new Vector3(-6.3f, -3.615f, 0f);
                    //SceneManager.LoadScene(SampleScene,LoadSceneMode.Single);
                }
                
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
