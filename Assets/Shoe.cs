using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shoe : MonoBehaviour
{

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float length;

    [SerializeField]
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
    }


    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delay);
        transform.DOMoveY(transform.position.y + yMax, length).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }


}
