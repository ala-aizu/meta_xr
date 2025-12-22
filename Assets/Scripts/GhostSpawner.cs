using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float spawnTimer = 1;
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
        if (!MRUK.Instance || !MRUK.Instance.IsInitialized)
        {
            Debug.LogWarning("MRUK is not initialized.");
            return;
        }
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        
        int currentTry = 0;
       while(currentTry < 1000)
       {
           bool hasFoundPosition = room.GenerateRandomPositionOnSurface(
               MRUK.SurfaceType.VERTICAL,
               .3f,
               new LabelFilter(MRUKAnchor.SceneLabels.WALL_FACE),
               out Vector3 pos,
               out Vector3 norm
           );
           if (hasFoundPosition) {  
               Vector3 position = pos + norm * 1f;
               position.y = 0;
               Instantiate(ghostPrefab, position, Quaternion.identity);
               return;
           }
           else {
               Debug.Log("Failed to find position. Try: " + currentTry);
               currentTry++;
           }
       }

    }

}
