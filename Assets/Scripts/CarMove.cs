using System;
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
    private Direction _carDirection;
    private Vector3 _movementVector;
    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SetCarAlignment();
        SetCarDirection();
        _movementVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += _movementVector;
        _rigidbody.velocity = _movementVector * speed;
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

    private float DirectionToAngle(Direction direction)
    {
        if (direction == Direction.Left)
            return 0;
        else if (direction == Direction.Up)
            return 90;
        else if (direction == Direction.Right)
            return 180;
        else if (direction == Direction.Down)
            return 270;

        else return -1;
    }

    private Vector3 VectorFromDirectionCompare(Direction direction)
    {
        if (direction == _carDirection)
        {
            return transform.forward;
        }

        float targetAngle = DirectionToAngle(direction);
        float carAngle = DirectionToAngle(_carDirection);

        if (Math.Abs(targetAngle - carAngle) == 180)
            return transform.forward * -1;


        else return Vector3.zero;
    }

    private Vector3 VectorFromDirection(Direction direction)
    {
        if (direction == Direction.Down)
        {
            return new Vector3(-speed, 0, 0);
        }
        else if (direction == Direction.Up)
        {
            return new Vector3(speed, 0, 0);
        }
        else if (direction == Direction.Right)
        {
            return new Vector3(0, 0, -speed);
        }
        else if (direction == Direction.Left)
        {
            return new Vector3(0, 0, speed);
        }
        else return Vector3.zero;
    }

    public void MoveOrder(Direction direction)
    {
        if (_carAlignment == DirectionToAlignment(direction))
        {
            _movementVector = VectorFromDirectionCompare(direction);
        }
        else
        {
            Shake();
        }
    }

    private void Shake()
    {
        //Debug.Log("SHAKE!");
    }

    public void Stop()
    {
        _movementVector = Vector3.zero;
    }

    private void OnMouseUp()
    {
        SetCarAlignment();
        Debug.Log(_carAlignment);
    }

    private void SetCarAlignment()
    {
        float rotation = transform.rotation.eulerAngles.y;
        //Debug.Log("Rotation Y: " + transform.rotation.eulerAngles.y);
        if (rotation is 90 or -90)
        {
            _carAlignment = CarAlignment.Vertical;
        }
        else if (rotation is 0 or 180)
        {
            _carAlignment = CarAlignment.Horizontal;
        }
    }

    private void SetCarDirection()
    {
        int rotation = (int)transform.rotation.eulerAngles.y;
        if (rotation == 0)
        {
            _carDirection = Direction.Left;
        }
        else if (rotation == 90)
        {
            _carDirection = Direction.Up;
        }
        else if (rotation == 180)
        {
            _carDirection = Direction.Right;
        }
        else if (rotation == 270)
        {
            _carDirection = Direction.Down;
        }
    }

    private void Turn()
    {
        Vector3 originalPosition = _movementVector;
        Vector3 targetPosition = Vector3.right * speed;
        _movementVector = Vector3.Lerp(originalPosition, targetPosition, Time.deltaTime);
    }

    void OnTriggerExit(Collider currentCollider)
    {
        GameObject other = currentCollider.gameObject;

        if (other.name == "Conveyor")
        {
            transform.rotation *= Quaternion.Euler(0, 90, 0);
            _movementVector = transform.forward;
        }
        if (other.name == "ConveyorFlip")
        {
            transform.rotation *= Quaternion.Euler(0, -90, 0);
            _movementVector = transform.forward;
        }
    }
}