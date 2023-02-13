using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEdgeCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraController parentScript = transform.parent.GetComponent<CameraController>();

            // Tells the parent script that a collision occured on left end. (-1 stands for left movement)
            parentScript.MoveCamera(-1);
        }
    }
}
