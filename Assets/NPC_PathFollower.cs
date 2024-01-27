using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_PathFollower : MonoBehaviour
{

    public PathCreator path;

    [SerializeField]
    private float speed;

    private float distanceTraveled;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distanceTraveled);
        transform.rotation = path.path.GetRotationAtDistance(distanceTraveled);
    }
}
