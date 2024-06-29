using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    public static bool[] chairPassed;

    void Awake()
    {
        GameObject[] chairPoints = GameObject.FindGameObjectsWithTag("ChairPoint");
        chairPassed = new bool[chairPoints.Length];
        for (int i = 0; i < chairPassed.Length; i++)
            chairPassed[i] = false;
    }
}
