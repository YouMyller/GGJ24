using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField]
    private Slider mainSlider;

    public bool active;

    public bool seen;

    private void Update()
    {
        if(active == true)
        {
            mainSlider.value += Time.deltaTime;
            //Debug.Log(mainSlider.value);
        }

        if(seen == true)
        {
            mainSlider.value += Time.deltaTime;
        }

        if (active == false && seen == false)
        {
            mainSlider.value = 0;
            //Debug.Log(mainSlider.value);
        }

        //Debug.Log(seen);

        
    }

}
