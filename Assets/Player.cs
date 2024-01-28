using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        mainSlider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Finn")
        {
            mainSlider.value = mainSlider.maxValue;
        }
    }
}
