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
    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SetCarAlignment();
        _movementVector = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += _movementVector;
        _rigidbody.velocity = _movementVector;
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
            _movementVector = VectorFromDirection(direction);
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
}