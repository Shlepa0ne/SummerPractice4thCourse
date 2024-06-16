using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private int value = 60;
    
    // Update is called once per frame
    void OnValidate()
    {
        Application.targetFrameRate = value;
    }
}
