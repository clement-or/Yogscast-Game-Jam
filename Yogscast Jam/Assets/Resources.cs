using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public float food = 50f;
    public float electricity = 50f;
    public float carbonDioxyde = 0;
    public float waste = 0;

    public Slider foodBar;
    public Slider electricityBar;
    public Slider wasteBar;
    public Slider carbonDioxydeBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foodBar.value = food;
        electricityBar.value = electricity;
        wasteBar.value = waste;
        carbonDioxydeBar.value = carbonDioxyde;
    }

    public float TakeFood(float n)
    {
        if (n > 0)
        {
            if (n > food)
            {
                float returnValue = food;
                food = 0;
                return returnValue;
            } else
            {
                food -= n;
                return n;
            }
        } else
        {
            food = Mathf.Clamp(food - n, 0, 100);
            return 0;
        }
    }

    public float TakeElectricity(float n)
    {
        if (n > 0)
        {
            if (n > electricity)
            {
                float returnValue = electricity;
                electricity = 0;
                return returnValue;
            }
            else
            {
                electricity -= n;
                return n;
            }
        }
        else
        {
            electricity = Mathf.Clamp(electricity - n, 0, 100);
            return 0;
        }
    }

    public float TakeWaste(float n)
    {
        if (n > 0)
        {
            if (n > waste)
            {
                float returnValue = waste;
                waste = 0;
                return returnValue;
            }
            else
            {
                waste -= n;
                return n;
            }
        }
        else
        {
            waste = Mathf.Clamp(waste - n, 0, 20);
            return 0;
        }
    }

    public float TakeCD(float n)
    {
        if (n > 0)
        {
            if (n > carbonDioxyde)
            {
                float returnValue = carbonDioxyde;
                carbonDioxyde = 0;
                return returnValue;
            }
            else
            {
                carbonDioxyde -= n;
                return n;
            }
        }
        else
        {
            carbonDioxyde = Mathf.Clamp(carbonDioxyde - n, 0, 30);
            return 0;
        }
    }

}
