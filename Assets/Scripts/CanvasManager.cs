using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public MovingVisitor movingVisitor;
    public CanvasManager canvasManager;

    private int chairNumber;
    private bool satDown = false;

    void Start()
    {
        chairNumber = movingVisitor.ChairNumber;
    }

    private void FixedUpdate()
    {
        if (!satDown && ChairManager.chairPassed[chairNumber] == true)
        {
            satDown = true;
            HideCanvas();
        }
    }

    public void ShowCanvas()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void HideCanvas()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
