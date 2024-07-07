using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public MovingVisitor movingVisitor;
    //public AutoMovingCube autoMovingCube;

    public Image brainImage;
    public Image lightImage;
    public Image hamburgerImage;
    public Image circleImage;

    private int chairNumber;
    private int timer = 0;
    private bool isSitting = false;
    public bool readyToOrder = false;    

    public void Start()
    {
        transform.rotation = Quaternion.Euler(-45f, 135f, 0f);
        //autoMovingCube = FindObjectOfType<AutoMovingCube>();
    }

    private void FixedUpdate()
    {
        //transform.LookAt(Camera.main.transform.position);
        if (movingVisitor != null)
            chairNumber = movingVisitor.ChairNumber;
        if (chairNumber >= 0)
            if (!isSitting && ChairManager.chairPassed[chairNumber] == true)
            {
                isSitting = true;
                transform.position = ChairManager.seatingPlace[chairNumber].transform.position + new Vector3(0f, 1.5f, 0f);
                ShowBrain();
            }
        if (isSitting)
            timer += 1;
        if (timer == 100)
        {
            HideBrain();
            ShowLight();
            readyToOrder = true;
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