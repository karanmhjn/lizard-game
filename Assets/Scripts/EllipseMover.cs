using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseMover : MonoBehaviour
{
    // CentreObject is an empty object used as center (the parent object)
    private Transform centreObject;
    
    // Used to make enemy move

    [SerializeField] private float RotationSpeed = 1f;
    [SerializeField] private float xRadius = 2f;
    [SerializeField] private float yRadius = 0.5f;

    private float ElevationOffset = 0;      // Always keep it 0 for 2D (defines z movement)
    
    private Vector3 positionOffset;
    private float angle = 0;

    // Used to make enemy shoot

    [SerializeField] private GameObject bullet;

    [SerializeField] private float fireRatemin;
    [SerializeField] private float fireRatemax;
    [SerializeField] private float nextFire = 3.0f;
    

    private void Start()
    {
        // Sets the parent as Centre of movement
        centreObject = this.transform.parent;
    }

    private void Update()
    {
        // Makes the enemy move in an ellipse around the centre
        positionOffset.Set(Mathf.Cos( angle ) * xRadius, Mathf.Sin( angle ) * yRadius,  ElevationOffset);
        transform.position = centreObject.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + Random.Range (fireRatemin, fireRatemax);
            Instantiate (bullet, transform.position, transform.rotation);
        }
    }
}
