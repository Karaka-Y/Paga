using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject creeperPrefab;
    public GameObject flyerPrefab;
    public int creeperCount;
    public int flyerCount;
    private ScreenBoundaries boundaries;

    // Start is called before the first frame update
    void Start()
    {
        boundaries = GetComponent<ScreenBoundaries>();
        SpawnEnemies();
    }

    private Vector3 PositionToSpawn(GameObject prefab){
        float zFieldLength = boundaries.upperPlaneBound - boundaries.lowerZBorder;
        float x = Random.Range(boundaries.leftXBorder, boundaries.rightXBorder);
        Debug.Log(x);
        float z = Random.Range(boundaries.lowerZBorder + (zFieldLength * 2/3), boundaries.upperPlaneBound);
        return new Vector3 (x, prefab.transform.position.y, z);
    }
    private void SpawnEnemies(){
        for (int i = 0; i < creeperCount; i++){
            var c = Instantiate(creeperPrefab, PositionToSpawn(creeperPrefab), Quaternion.identity) as GameObject;
        }
        for (int i = 0; i < flyerCount; i++){
            var f = Instantiate(flyerPrefab, PositionToSpawn(flyerPrefab), Quaternion.identity) as GameObject;
        }
    }
}
