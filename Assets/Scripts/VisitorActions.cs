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

    //    //// ��������� �����-�� ��������
    //    //Debug.Log("������� ���������: " + Time.time);

    //    //// ���� 2 �������
    //    yield return new WaitForSeconds(2);

    //    //// ��������� ������ �������� ����� ��������
    //    //Debug.Log("������ 2 �������: " + Time.time);
    //}
}
