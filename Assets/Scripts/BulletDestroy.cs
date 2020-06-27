using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField]
    private float deactivateTime = 2f;
    void OnEnable() {
        StartCoroutine("DeactivateTimer");
    }
    IEnumerator DeactivateTimer(){
        yield return new WaitForSeconds(deactivateTime);
        this.gameObject.SetActive(false);
    }
}
