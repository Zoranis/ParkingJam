using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    private int _initialCarCount;
    private int _carsLeaveCount = 0;
    [SerializeField] private Text winText;


    private void Start()
    {
        _initialCarCount = GameObject.FindGameObjectsWithTag("Car").Length;
    }

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
        winText.gameObject.SetActive(true);
    }
}
