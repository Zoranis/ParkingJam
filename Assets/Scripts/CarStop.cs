using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarStop : MonoBehaviour
{

    [SerializeField] private CarMove carMove;
    void OnCollisionEnter(Collision collision)
    {
        carMove.Stop();

        CarMove otherCar = collision.collider.gameObject.GetComponent<CarMove>();

        if (otherCar != null)
        {
            otherCar.Stop();
        }
    }
}