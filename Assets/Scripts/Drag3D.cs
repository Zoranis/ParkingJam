using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drag3D : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZcoord;

    public void OnMouseDown()
    {
        mZcoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZcoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
        //Vector3 mousePosition = Input.mousePosition;
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    
}
