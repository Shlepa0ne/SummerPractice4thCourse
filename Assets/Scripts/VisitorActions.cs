using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorActions : MonoBehaviour
{
    public MovingVisitor movingVisitor;
    public CanvasManager canvasManager;

    private int chairNumber;
    private bool satDown = false;

    //void Awake()
    //{
    //    canvasObject.SetActive(false);
    //}

    //private void FixedUpdate()
    //{
    //    chairNumber = movingVisitor.ChairNumber;
    //    if (!satDown && ChairManager.chairPassed[chairNumber] == true)
    //    {
    //        satDown = true;
    //        canvasManager.HideCanvas();
    //    }
    //}

    //IEnumerator CanvasCoroutine()
    //{
    //    canvasInstance = Instantiate(canvasPrefab, transform.position + offset, Quaternion.identity);

    //    //// Выполняем какое-то действие
    //    //Debug.Log("Корутин стартовал: " + Time.time);

    //    //// Ждем 2 секунды
    //    yield return new WaitForSeconds(2);

    //    //// Выполняем другое действие после задержки
    //    //Debug.Log("Прошло 2 секунды: " + Time.time);
    //}
}
