using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    GameObject fppCamera;
    Joystick joystick;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        fppCamera = GameObject.FindGameObjectWithTag("MainCamera");
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        var moveDirection = transform.forward * vertical + transform.right * horizontal;
        gameObject.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * speed, ForceMode.Impulse);
    }
}
