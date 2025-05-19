using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Scanner : MonoBehaviour
{
    public RaycastHit2D[] targets;
    public float scanRange;
    public LayerMask targetLayer;
    public Transform nearestTarget;

    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector3.zero, 0, targetLayer);
        nearestTarget = FindNearTarget();
    }

    Transform FindNearTarget(){
        Transform result = null;
        float nearDis = 100;

        foreach(RaycastHit2D target in targets){
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;
            float diffDis = Vector3.Distance(mypos, targetpos);
            if(diffDis < nearDis) result = target.transform;
        }

        return result;


    }
}
