using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMove : MonoBehaviour
{
    [Range(-1, 1)]
    public float DirectionX;
    [Range(-1, 1)]
    public float DirectionY;
    [Range(-1, 1)]
    public float DirectionZ;

    Vector3 Dir; // Direction to travel in

    public float Speed = 1f;

    void Start()
    {
        Dir = new Vector3(DirectionX, DirectionY, DirectionZ);
    }
    private void FixedUpdate()
    {
        transform.Translate(Dir * Speed);
    }
}
