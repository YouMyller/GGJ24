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

    public bool dead;

    private void Update()
    {
        if(active == true && dead == false)
        {
            mainSlider.value += Time.deltaTime;
            //Debug.Log(mainSlider.value);
        }

        if(seen == true && dead == false)
        {
            mainSlider.value += Time.deltaTime;
            Debug.Log(mainSlider.value);
        }

        if (active == false && seen == false && dead == false)
        {
            mainSlider.value = 0;
            //Debug.Log(mainSlider.value);
        }

        if(dead == true)
        {
            mainSlider.value = mainSlider.maxValue;
        }

        //Debug.Log(seen);

        
    }

}
