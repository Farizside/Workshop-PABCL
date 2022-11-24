using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
    private int _coins;

    public Text coinText;

    public void Start()
    {
        _coins = 0;
    }

    public void Update()
    {
        DisplayCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            _coins++;
            Destroy(other.gameObject);
        }
    }

    private void DisplayCoin()
    {
        coinText.text = _coins.ToString();
    }
}
