using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public float food = 50f;
    public float electricity = 50f;

    public Slider foodBar;
    public Slider electricityBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foodBar.value = food;
        electricityBar.value = electricity;
    }

    public float TakeFood(float n)
    {
        float diff = food - n;
        if (diff < 0)
        {
            float returnValue = food;
            food = 0;
            return returnValue;
        } else
        {
            food = diff;
            return n;
        }
    }

    public float TakeElectricity(float n)
    {
        float diff = electricity - n;
        if (diff < 0)
        {
            electricity = 0;
            return electricity;
        } else
        {
            electricity = diff;
            return electricity;
        }
    }
}
