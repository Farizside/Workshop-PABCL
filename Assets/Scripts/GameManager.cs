using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    
    public Image[] stars;

    public PickupScript pickupScript;

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        DisplayStars();
        if (pickupScript.GetCoins() == stars.Length)
        {
            isGameOver = true;
        }
    }

    void DisplayStars()
    {
        for (int i = 0; i < pickupScript.GetCoins(); i++)
        {
            stars[i].color = Color.black;
        }
    }
}
