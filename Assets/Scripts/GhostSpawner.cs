using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
   public GameObject ghostPrefab;
   public float spawnTimer =1;
   public float timer;

   void Update()
   {
       timer += Time.deltaTime;
       if (timer >= spawnTimer)
       {
           SpawnGhost();
           timer -= spawnTimer;
       }
   }

   public void SpawnGhost()
   {
       Vector3 position = Random.insideUnitSphere *3;
       position.y = 0;

       Instantiate(ghostPrefab, position, Quaternion.identity);
   }
}
