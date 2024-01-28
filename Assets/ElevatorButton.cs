using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    private bool onButton;

    [SerializeField]
    GameObject player;

    [SerializeField]
    private float minDistanceToPlayer;

    [SerializeField]
    private GameObject instructions;

    [SerializeField]
    private GameObject Finish;

    [SerializeField]
    private GameObject elevatorDoorObject;
    private Animator elevatorDoorAnimation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        instructions.gameObject.SetActive(false);
        Finish.gameObject.SetActive(false);
        elevatorDoorAnimation = elevatorDoorObject.GetComponent<Animator>();
        elevatorDoorAnimation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(player.transform.position, transform.position) < minDistanceToPlayer)
        {
            print("Button pressed");
            Finish.gameObject.SetActive(true);

            elevatorDoorAnimation.enabled = true;
            elevatorDoorAnimation.Play("NewElevator");
        }

        if(onButton == true && Vector3.Distance(player.transform.position, transform.position) < minDistanceToPlayer)
        {
            instructions.gameObject.SetActive(true);
        }

    }

    void OnMouseOver()
    {
        onButton = true;
        
    }

    void OnMouseExit()
    {
        onButton = false;
        instructions.gameObject.SetActive(false);
    }
}
