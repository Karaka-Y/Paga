using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public float height;
    public float width;
    public float planeHeightScaler;
    public float upperPlaneBound;
    private MeshRenderer mesh;
    public float leftXBorder;
    public float rightXBorder;
    public float upperZBorder;
    public float lowerZBorder;
    private float objectHeight;
    private float objectWidth;
    
    void Start()
    {   if(this.gameObject.GetComponent<MeshRenderer>() != null)
        {
            mesh = GetComponent<MeshRenderer>();
            objectHeight = mesh.bounds.size.y;
            objectWidth = mesh.bounds.size.x;
        }
        else {
            objectHeight = 1;
            objectWidth = 1;
        }
        
        height = 2*Camera.main.orthographicSize;
        width = height*Camera.main.aspect;
        planeHeightScaler = height / (((height/2) * (Mathf.Sqrt(3)/2)) * 2);
        upperPlaneBound = (height/2 * planeHeightScaler) - ((transform.position.y + (objectHeight/2)) / Mathf.Tan(Mathf.PI / 3));
        Debug.Log(gameObject.name + " " + objectHeight);
        leftXBorder = (-width/2) + objectWidth / 2;
        rightXBorder = width/2 - objectWidth / 2;
        upperZBorder = -(height/2 * planeHeightScaler);
        lowerZBorder = upperPlaneBound;

    }

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, leftXBorder, rightXBorder);
        position.z = Mathf.Clamp(position.z, upperZBorder, lowerZBorder);
        transform.position = position;
    }
}
