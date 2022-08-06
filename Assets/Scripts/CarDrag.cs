using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        Debug.Log("Drag");
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }
    
    
}
