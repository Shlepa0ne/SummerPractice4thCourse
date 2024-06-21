using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject VisitorsPrefab;
    [SerializeField] private float timeToSpawn = 1f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Spawn()
    { 
        GameObject visitor = Instantiate(VisitorsPrefab);
        visitor.transform.position = spawnPoint.position;
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
