using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

public class Triggers : MonoBehaviour
{
    public static bool visitorEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Visitor")
        {
            visitorEntered = true;
            Debug.Log("A visitor has entered");
        }
    }
}
