using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderDistanceComparer : IComparer
{
    private Transform gunTransform;
    public Transform GunTransform{
        get
        {
            return gunTransform;
        }
        set
        {
            gunTransform = value;
        }
    }
    public int Compare(object x, object y){
        Collider col1 = x as Collider;
        Collider col2 = y as Collider;
        Vector3 positionToCompare = gunTransform.position;
        float distanceToFirstObject = Vector3.Distance(positionToCompare, col1.transform.position);
        float distanceToSecondObject = Vector3.Distance(positionToCompare, col2.transform.position);
        if(distanceToFirstObject < distanceToSecondObject){
            return -1;
        }
        if(distanceToFirstObject == distanceToSecondObject){
            return 0;
        }
        else{
            return 1;
        }
    }
}
