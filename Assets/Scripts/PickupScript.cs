using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
    private int _coins;

    public void Start()
    {
        _coins = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            _coins++;
            Destroy(other.gameObject);
            Debug.Log(_coins);
        }
    }

    public int GetCoins()
    {
        return _coins;
    }
}
