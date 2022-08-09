using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public enum CarAlignment
{
    Vertical, Horizontal
}

public class CarMove : MonoBehaviour
{

    [SerializeField] private float speed = 0.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        transform.position = new(position.x + speed, position.y, position.z);
    }
    
    
    
}
