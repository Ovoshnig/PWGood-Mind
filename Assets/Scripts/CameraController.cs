using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    private Vector3 collision = Vector3.zero;
    [SerializeField] private GameObject lastHit;

    [SerializeField, Description("Чувствительность мыши")] private float sensetivityMouse;
    public Transform Player;
    [SerializeField] private Rigidbody playerRigidbody;
    private float xRotation = 0f;

    public GameObject LastHit { get => lastHit; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        playerRigidbody.angularVelocity = Vector3.zero;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            sensetivityMouse += 2;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && sensetivityMouse - 2 > 0) 
            sensetivityMouse -= 2;

        mouseX = Input.GetAxis("Mouse X") * sensetivityMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensetivityMouse * Time.deltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0));
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(-mouseY * new Vector3(1, 0, 0));
    }

    private void LateUpdate()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);
#endif
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5)) 
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
        }
        else
        {
            lastHit = null;
        }
    }
}
