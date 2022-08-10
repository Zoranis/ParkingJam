using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarStop : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        CarMove otherCar = collision.collider.gameObject.GetComponent<CarMove>();

        if (otherCar != null)
        {
            otherCar.Stop();
        }
    }
}