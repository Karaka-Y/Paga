using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerMoving : MonoBehaviour
{
    public float flyDistance = 3f;
    public float flyerSpeed = 1f;
    public float bulletSpeed = 2000f;
    private Vector3 movingDestination;
    private bool canMove = false;
    private bool aimingTarget = false;
    public Transform target;
    private MeshRenderer mesh;
    private ScreenBoundaries boundaries;
    private float timeToMove;

    // Start is called before the first frame update
    void Start()
    {
        boundaries = GetComponent<ScreenBoundaries>();
        mesh = GetComponent<MeshRenderer>();
        if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
        StartCoroutine("FlyerActions");
    }

    // Update is called once per frame
    void Update()
    {
        timeToMove = flyDistance / flyerSpeed;
        if(transform.position.x == boundaries.leftXBorder || transform.position.x == boundaries.rightXBorder){
            transform.Rotate(0, 180, 0);
        }
        else if(transform.position.z == boundaries.upperZBorder || transform.position.z == boundaries.lowerZBorder){
            transform.Rotate(0, 180, 0);
        }
    }
    private void FixedUpdate() {
        if(canMove){
            Move();
        }
        if(aimingTarget){
            transform.LookAt(target);
        }
    }
    private void ChooseDirection(){
        int angle = Random.Range(0, 360);
        transform.Rotate(0, angle, 0);
    }
    private void Move(){
        transform.Translate(Vector3.forward * flyerSpeed * Time.deltaTime, Space.Self);
    }
    private void Shoot(){
       GameObject bullet = ObjectPooler.instance.SpawnFromPool("FlyerBullets", transform.position, Quaternion.identity);
        bullet.transform.LookAt(target);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
    }
    IEnumerator MovingTimer(float timeToMove){
        canMove = true;
        yield return new WaitForSeconds(timeToMove);
        canMove = false;
    }

    IEnumerator FlyerActions(){
        ChooseDirection();
        StartCoroutine(MovingTimer(timeToMove));
        yield return new WaitWhile(() => canMove);
        aimingTarget = true;
        yield return new WaitForSeconds(1f);
        Shoot();
        aimingTarget = false;
        transform.eulerAngles = Vector3.zero;
        StartCoroutine("FlyerActions");
    }

}

