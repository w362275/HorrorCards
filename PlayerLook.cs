using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSpeed;
    public Transform player;
    float xRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Locks cursor to center screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Detects mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        //Uses y-value to determine how far the player can look around while capping rotation
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //Applies rotation to camera and player object
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
