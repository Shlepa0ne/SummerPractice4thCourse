using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public MovingVisitor movingVisitor;

    public Image brainImage;
    public Image lightImage;
    public Image hamburgerImage;
    public Image circleImage;

    private int chairNumber;
    private bool isSitting = false;

    public void Start()
    {
        //chairNumber = movingVisitor.ChairNumber;
    }

    private void FixedUpdate()
    {
        if (movingVisitor != null)
            chairNumber = movingVisitor.ChairNumber;
        if (!isSitting && ChairManager.chairPassed[chairNumber] == true)
        {
            isSitting = true;
            transform.position = ChairManager.seatingPlace[chairNumber].transform.position + new Vector3(0f, 1.5f, 0f);
            ShowBrain();
        }
    }

    public void ShowBrain()
    {
        brainImage.fillAmount = 1;
    }
    public void HideBrain()
    {
        brainImage.fillAmount = 0;
    }

    public void ShowLight()
    {
        lightImage.fillAmount = 1;
    }
    public void HideLight()
    {
        lightImage.fillAmount = 0;
    }

    public void ShowHamburger()
    {
        hamburgerImage.fillAmount = 1;
    }
    public void HideHamburger()
    {
        hamburgerImage.fillAmount = 0;
    }
    
    public void ShowCircle()
    {
        circleImage.fillAmount = 1;
    }
    public void HideCircle()
    {
        circleImage.fillAmount = 0;
    }
}