using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCar : MonoBehaviour
{
    private Vector3 _objectMouseOffset;
    private float _objectZcoords;

    public void OnMouseDown()
    {
        _objectZcoords = Camera.main.WorldToScreenPoint(transform.position).z;
        _objectMouseOffset = transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouseWorldPoint = Input.mousePosition;
        mouseWorldPoint.z = _objectZcoords;

        return Camera.main.ScreenToWorldPoint(mouseWorldPoint);
    }

    private Vector3 GetAxisDragPosition()
    {
        var mouseProjection = GetMouseWorldPos() + _objectMouseOffset;
        var position = transform.position;
        return new Vector3(mouseProjection.x, position.y, position.z);
    }
    
    private void OnMouseDrag()
    {
        transform.position = GetAxisDragPosition();
    }

}
