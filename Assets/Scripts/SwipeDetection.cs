using System;
using UnityEngine;

public enum Direction
{
    Up, Down, Right, Left, Error
}

public class SwipeDetection : MonoBehaviour
{
    private Vector2 _swipeStartPosition;
    private Vector2 _swipeEndPosition;
    [NonSerialized] public Direction SwipeDirection;
    [SerializeField] private CarMove carMove;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnMouseDown()
    {
        _swipeStartPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _swipeEndPosition = Input.mousePosition;
        //Debug.Log(AngleToDireciton());
        carMove.MoveOrder(AngleToDireciton());
    }

    private float GetSwipeAngle()
    {
        float swipeAngle = Vector2.SignedAngle((_swipeEndPosition - _swipeStartPosition), Vector2.up);
        if (swipeAngle < 0) swipeAngle += 360;
        return swipeAngle;
    }

    private Direction AngleToDireciton()
    {
        float angle = GetSwipeAngle();

        if (angle is > 0 and < 90)
            return Direction.Up;
        else if (angle is > 90 and < 180)
            return Direction.Right;
        else if (angle is > 180 and < 270)
            return Direction.Down;
        else if (angle is > 270 and < 360)
            return Direction.Left;

        return Direction.Error;
    } 
}
