using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSpawner : MonoBehaviour
{
    AutoMovingCube autoMovingCube;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject BurgerPrefab;
    public bool isSpawn = false;
    private int timer = 0;

    void Start()
    {
        autoMovingCube = FindObjectOfType<AutoMovingCube>();
    }

    void FixedUpdate()
    {
        if (!isSpawn && autoMovingCube.cameToKitchen == true)
        {
            timer++;
            if (timer > 30)
            {
                isSpawn = true;
                timer = 0;
                Spawn();
            }
        }
    }

    void Spawn()
    {
        GameObject Burger = Instantiate(BurgerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
