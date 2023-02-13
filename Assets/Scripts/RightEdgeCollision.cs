using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEdgeCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraController parentScript = transform.parent.GetComponent<CameraController>();
            Debug.Log("Right Collision");

            // Tells the parent script that a collision occured on right end. (+1 stands for right movement)
            parentScript.MoveCamera(1);
        }
    }
}
