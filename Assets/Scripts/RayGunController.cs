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

    public LayerMask layerMask;

    public AudioSource source;
    public AudioClip clip;

    public GameObject rayImpactPrefab;

    void Update()
    {
        if (OVRInput.GetDown(triggerButton))
        {
            Shoot();
        }
    }
        
    public void Shoot() 
    {
        source.PlayOneShot(clip);
        
        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance);
        
        Vector3 endPoint = Vector3.zero;

        if (hasHit)
        {
            endPoint = hit.point;   

            Quaternion rotation = Quaternion.LookRotation(-hit.normal);
            GameObject rayImpact = Instantiate(rayImpactPrefab, hit.point, rotation);
            Destroy(rayImpact, 1);
        }
        else
        {
            endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;
        }
        
        LineRenderer line = Instantiate(linePrefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);
        
        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowTimer);

    }

}
