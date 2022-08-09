using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public enum CarAlignment
{
    Vertical,
    Horizontal,
    Error
}

public class CarMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    private CarAlignment _carAlignment;
    private Vector3 _movementVector;


    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y is 90 or -90)
        {
            _carAlignment = CarAlignment.Vertical;
        }
        else if (transform.position.y is 0 or 180)
        {
            _carAlignment = CarAlignment.Horizontal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        transform.position += new(position.x, position.y, position.z);
    }

    private CarAlignment DirectionToAlignment(Direction swipeDirection)
    {
        if (swipeDirection is Direction.Down or Direction.Up)
            return CarAlignment.Vertical;
        else if (swipeDirection is Direction.Right or Direction.Left)
        {
            return CarAlignment.Horizontal;
        }
        else return CarAlignment.Error;
    }
}