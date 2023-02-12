using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The camera should follow the player
    [SerializeField] private Transform player;

	[SerializeField] private float sideBoundaryLength = 10f;

    [SerializeField] private float shift = 8f;

    [SerializeField] private float damping = 5f;

	void Start ()
    {

		// the map MinX and MinY are the position that the camera STARTS
		// minX = transform.position.x;
		// minY = transform.position.y;
        // minZ = transform.position.z;
		// // the desired max boundaries
		// maxX = mapX;
		// maxY = mapY;
	}

	void Update ()
    {

        Vector3 wantedPosition = transform.position;

        float rightBoundary = transform.position.x + sideBoundaryLength;
        float leftBoundary = transform.position.x - sideBoundaryLength;

		if (player.transform.position.x>rightBoundary)
        {
            wantedPosition.x += shift;
        }

        else if (player.transform.position.x<leftBoundary)
        {
            wantedPosition.x -= shift;
        }

        // set the camera to go to the wanted position in a certain amount of time
        transform.position = Vector3.Lerp (transform.position, wantedPosition, (Time.deltaTime * damping));
	}
}
