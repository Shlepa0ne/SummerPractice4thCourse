using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorSpawner : MonoBehaviour
{
    public List<GameObject> visitors = new List<GameObject>();

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject VisitorsPrefab;
    [SerializeField] private GameObject CanvasPrefab;
    private float timeToSpawn;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Spawn()
    { 
        GameObject visitor = Instantiate(VisitorsPrefab, spawnPoint.position, Quaternion.identity);
        GameObject canvas = Instantiate(CanvasPrefab, spawnPoint.position, Quaternion.identity);
        MovingVisitor movingVisitor = visitor.GetComponent<MovingVisitor>();
        CanvasManager canvasManager = canvas.GetComponent<CanvasManager>();
        canvasManager.movingVisitor = movingVisitor;

        visitors.Add(visitor);
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            timeToSpawn = Random.Range(2.0F, 5.0F);
            yield return new WaitForSeconds(timeToSpawn);
            Spawn();
        }
    }
}
