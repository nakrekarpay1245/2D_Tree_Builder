using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost;

    public int goldIncrease;

    public float timeBetweenIncrease;
    private float nextIncreaseTime;

    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBetweenIncrease;
            gameManager.gold += goldIncrease;
        }
    }
}
