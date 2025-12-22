using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed =1;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!agent)
        {
            Debug.LogWarning("Failed to find NavMeshAgent");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent) return;
        
        Vector3 target = Camera.main.transform.position;

        agent.SetDestination(target);
        agent.speed = speed;
    }

    public void KillGhost()
    {
        Destroy(this.gameObject);
    }
}
