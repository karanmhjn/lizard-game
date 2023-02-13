using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    // CentreObject is an empty object used as center (the parent object)
    private Transform centreObject;
    
    [SerializeField] private float RotationSpeed = 1;
    
    [SerializeField] private float CircleRadius = 1;
    
    // Always keep it 0 for 2D (defines z movement)
    private float ElevationOffset = 0;
    
    private Vector3 positionOffset;
    private float angle = 0;
    

    private void Start()
    {
        // _transform = GetComponentInChildren<Transform>();
        centreObject = this.transform.parent;
    }

    private void Update()
    {
        positionOffset.Set(Mathf.Cos( angle ) * CircleRadius, Mathf.Sin( angle ) * CircleRadius,  ElevationOffset);
        transform.position = centreObject.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }
}
