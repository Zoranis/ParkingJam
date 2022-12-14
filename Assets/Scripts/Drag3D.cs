using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drag3D : MonoBehaviour
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
    
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _objectMouseOffset;
        //Vector3 mousePosition = Input.mousePosition;
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    
}
