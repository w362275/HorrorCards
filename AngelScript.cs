using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelScript : MonoBehaviour
{
    public Transform player;
    Renderer angelRender;
    NavMeshAgent angelAgent;
    bool setActive = false;

    RaycastHit obstacle;
    public Transform playerCam;

    // Start is called before the first frame update
    void Start()
    {
        //Fetches relevant components
        angelRender = GetComponent<Renderer>();
        angelAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calls function to check direct path between player and angel
        CheckPath();

        //Checks whether angel is visible
        if ((!angelRender.isVisible || obstacle.transform.tag == "Obstacle") && setActive)
        {
            //Updates angel goal
            angelAgent.destination = player.position;
        }
        else
        {
            //Forces angel to stop
            angelAgent.destination = gameObject.transform.position;
        }

        if (angelRender.isVisible && !setActive)
        {
            setActive = true;
        }
    }

    void CheckPath()
    {
        //Fires raycast from camera to angel to check whether or not angel can be seen behind obstacles
        float angleCheck = Mathf.Atan2(transform.position.x - playerCam.position.x, transform.position.z - playerCam.position.z) * Mathf.Rad2Deg;
        playerCam.rotation = Quaternion.Euler(0f, angleCheck, 0f);
        Physics.Raycast(playerCam.position, playerCam.forward, out obstacle);
    }
}
