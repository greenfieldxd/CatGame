using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformHorizontal : MonoBehaviour
{
    [SerializeField] private float vectorX;
    [SerializeField] private float vectorY;
    [SerializeField] private int speed;

    [SerializeField] Vector3 target;
    private Vector3 defaultVector;
    private bool checkerPositions;
    void Start()
    {
        checkerPositions = false;
        target.y = transform.position.y;
        target.z = 0f;
        defaultVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkerPositions)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }
        if (checkerPositions)
        {
            transform.position = Vector2.MoveTowards(transform.position, defaultVector, Time.deltaTime * speed);
        }
        if (transform.position == target) checkerPositions = true;
        if (transform.position == defaultVector) checkerPositions = false;
    }


}
