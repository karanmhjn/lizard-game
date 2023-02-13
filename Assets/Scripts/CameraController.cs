using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float shift = 8f;

    // Moves camera to the left or right.
    // Direction takes value 1 for moving right and -1 for moving left.
    public void MoveCamera(int direction)
    {
        Vector3 wantedPosition = transform.position;

        wantedPosition.x += shift*direction;

        // Doesn't work as we get multiple triggers when moving the trigger slowly.
            // set the camera to go to the wanted position in a certain amount of time
            // (Time.deltaTime * damping)
            // transform.position = Vector3.Lerp (transform.position, wantedPosition, 0);

        // Set the camera position to wanted position
        transform.position = wantedPosition;

    }
}
