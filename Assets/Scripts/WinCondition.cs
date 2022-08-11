using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int _initialCarCount;
    private int _carsLeaveCount = 0;
    
    void OnTriggerExit(Collider currentCollider)
    {
        GameObject other = currentCollider.gameObject;

        if (other.CompareTag("Car"))
        {
            Debug.Log("Car Left");
            _carsLeaveCount++;
        }
        
        TestWin();
    }

    private void TestWin()
    {
        if (_carsLeaveCount == _initialCarCount)
            Win();
    }

    private void Win()
    {
        
    }
}
