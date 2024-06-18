using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject VisitorsPrefab;
    [SerializeField] private float timeToSpawn;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Spawn()
    { 
        GameObject visitor = Instantiate(VisitorsPrefab);
        visitor.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            Spawn();
        }
    }
}
