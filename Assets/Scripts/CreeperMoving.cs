using UnityEngine;

public class CreeperMoving : MonoBehaviour
{
    public float speed = 5.0f;
	public Transform target;
    private Rigidbody _body;

	// Use this for initialization
	void Start () 
	{
        _body = this.GetComponent<Rigidbody>();
		// if no target specified, assume the player
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null)
			return;

		// face the target
		transform.LookAt(target);
	}
    void FixedUpdate() {
        _body.velocity = transform.forward * speed * Time.deltaTime;
    }
}
