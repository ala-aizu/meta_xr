using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunController : MonoBehaviour
{
    public OVRInput.RawButton triggerButton;
    public LineRenderer linePrefab; 
    public Transform shootingPoint;
    public float maxLineDistance = 5;
    public float lineShowTimer = .3f;

    void Update()
    {
        if (OVRInput.GetDown(triggerButton))
        {
            Shoot();
        }
    }
        
    public void Shoot() 
    {
        Debug.Log("pew pew");
        LineRenderer line = Instantiate(linePrefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);
        
        Vector3 endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;
        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowTimer);
    }

}
