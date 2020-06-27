using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float heroSpeed;
    public Joystick joystick;
    private CharacterController _charController;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = joystick.Horizontal * heroSpeed;
        verticalInput = joystick.Vertical * heroSpeed;
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Vector3.ClampMagnitude(movement, heroSpeed);
        movement = movement * Time.deltaTime;
        _charController.Move(movement);
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
    }
}
