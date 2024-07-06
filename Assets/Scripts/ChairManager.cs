using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    public static bool[] chairPassed;
    public static int queueLength = 0;
    public static GameObject[] chairPoint;
    public static GameObject[] seatingPlace;
    public static GameObject[] burgerPoint;
    void Awake()
    {
        chairPoint = GameObject.FindGameObjectsWithTag("ChairPoint");
        seatingPlace = GameObject.FindGameObjectsWithTag("SeatingPlace");
        burgerPoint = GameObject.FindGameObjectsWithTag("BurgerPoint");
        chairPassed = new bool[chairPoint.Length];
        for (int i = 0; i < chairPassed.Length; i++)
            chairPassed[i] = false;
    }
}
