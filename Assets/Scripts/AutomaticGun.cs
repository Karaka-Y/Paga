using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutomaticGun : MonoBehaviour
{
    ColliderDistanceComparer distComparer;
    public Transform gunTransform;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private float gunRadius = 4f;
    [SerializeField]
    private LayerMask layerMask;
    private float bulletSpeed = 300f;
    private CharacterController _charController;
    private bool canShoot;
    private bool isreloaded = true;
    // Start is called before the first frame update
    void Start()
    {
        distComparer = new ColliderDistanceComparer();
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_charController.velocity == Vector3.zero){
            canShoot = true;
        }
        else{canShoot = false;}
        if(canShoot && isreloaded){
            Shoot(ChooseTarget());
        }
    }
    private Transform ChooseTarget(){
        distComparer.GunTransform = this.gunTransform;
        Collider[] colliders = Physics.OverlapSphere(gunTransform.position, gunRadius, layerMask);
        if(colliders.Length > 0){
            Array.Sort(colliders, distComparer);
            return colliders[0].transform;
        }
        return null;
    }
    private void Shoot(Transform target){
        if(target != null)
        {
            GameObject bullet = ObjectPooler.instance.SpawnFromPool("PlayerBullets", transform.position, Quaternion.identity);
            bullet.transform.LookAt(target);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
            isreloaded = false;
            StartCoroutine("GunReloading");
        }
    }
    IEnumerator GunReloading(){
        yield return new WaitForSeconds(fireRate);
        isreloaded = true;
    }

}
