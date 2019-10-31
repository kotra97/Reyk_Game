using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderMoving : MonoBehaviour
{
    public Slider slide;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSlider", 0f, 1.5f);
        slide.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveSlider()
    {
        Debug.Log(slide.value);
        if (slide.value < 0.3f)
        {
            slide.value += 0.5f;
        } else
        {
            slide.value -= 0.1f;
        }
        //num should be from 0 to 1, because that's the range of a slider
    }
}
