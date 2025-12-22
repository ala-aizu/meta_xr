using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using Meta.XR.MRUtilityKit;

public class RuntimeNavmeshBuilder : MonoBehaviour
{
    private NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        surface = GetComponent<NavMeshSurface>();

        MRUK.Instance.RegisterSceneLoadedCallback(OnSceneLoaded);
    }


    private void OnSceneLoaded()
    {
        StartCoroutine(BuildNavmeshRoutine());
    }

    private IEnumerator BuildNavmeshRoutine()
    {
        yield return new WaitForEndOfFrame();
        surface.BuildNavMesh();
    }
}