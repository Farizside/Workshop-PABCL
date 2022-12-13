using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    
    public bool isGameOver;
    
    public GameObject[] stars;

    public int collectedStars;

    void Start()
    {
        isGameOver = false;
        panel.SetActive(false);
        collectedStars = 0;
    }

    void Update()
    {
        if (collectedStars == stars.Length)
        {
            GameOver();
        }
    }

    public void DisplayStars()
    {
        for (int i = 0; i < collectedStars; i++)
        {
            stars[i].GetComponent<Image>().color = Color.yellow;
        }
    }
    

    void GameOver()
    {
        isGameOver = true;
        panel.SetActive(true);
        foreach (var star in stars)
        {
            star.SetActive(false);
        }
    }
}
