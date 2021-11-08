using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController playerChar;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Applies component from character
        playerChar = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calls function to move player
        MovePlayer();
    }

    void MovePlayer()
    {
        //Detects key input and assigns to player
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;     //Ensures movement relative to rotation
        playerChar.Move(move * speed * Time.deltaTime);
    }
}
