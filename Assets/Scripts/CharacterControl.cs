using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CharacterControl : MonoBehaviour
{
    Transform fppCamera;
    Joystick joystick;
    public FixedTouchField TouchField;

    PhotonView view;
    public float speed = 1f;
    float mouseX = 0;
    float mouseY = 0;
    float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        fppCamera = GetComponentInChildren<Camera>().transform;
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            mouseX += Input.GetAxis("Mouse X") * 0.01f;
            mouseY -= Input.GetAxis("Mouse Y") * 2f;
            mouseY = Mathf.Clamp(mouseY, -90f, 90f);
            fppCamera.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
            var horizontal = joystick.Horizontal;
            var vertical = joystick.Vertical;
            var moveDirection = transform.forward * vertical + transform.right * horizontal;

            gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * 0.0001f * speed, ForceMode.Impulse);
        }
    }
}
