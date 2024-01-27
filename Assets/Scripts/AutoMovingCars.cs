using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingCars : MonoBehaviour
{
    public enum TargetPoint
    {
        topLeft,
        topRight,
        bottomRight,
        bottomLeft,
    }

    [SerializeField] private int mySpeed = 40;

    private TargetPoint nextPoint = TargetPoint.topLeft;

    public Transform topLeftTransform;
    public Transform topRightTransform;
    public Transform bottomRightTransform;
    public Transform bottomLeftTransform;

    private Transform currentPoint;

    void Start()
    {
        currentPoint = topLeftTransform;

    }
    void Update()
    {
        Vector3 targetPoint = currentPoint.position;
        Vector3 moveDirection = currentPoint.position - transform.position;

        float distance = moveDirection.magnitude;

        if (distance > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, mySpeed * Time.deltaTime);
        }
        else
        {
            SetNextTarget(nextPoint);
        }

        Vector3 direction = currentPoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = targetRotation;
    }

    void SetNextTarget(TargetPoint target)
    {
        switch (target)
        {
            case TargetPoint.topLeft:
                currentPoint = topLeftTransform;
                nextPoint = TargetPoint.topRight;
                break;
            case TargetPoint.topRight:
                currentPoint = topRightTransform;
                nextPoint = TargetPoint.bottomRight;
                break;
            case TargetPoint.bottomRight:
                currentPoint = bottomRightTransform;
                nextPoint = TargetPoint.bottomLeft;
                break;
            case TargetPoint.bottomLeft:
                currentPoint = bottomLeftTransform;
                nextPoint = TargetPoint.topLeft;
                break;
        }
    }
}
