using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foetus : MonoBehaviour
{
    public float health = 100f;
    public float food = 100f;
    public float oxygen = 100f;
    public float waste = 0f;
    public float carbonDioxyde = 0f;
    public float mass = 0f;

    public Slider oxygenBar;
    public Slider wasteBar;
    public Slider carbonDioxydeBar;
    public Slider healthBar;
    public Slider massBar;

    public GameObject resources;

    private Resources resourcesScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateStats", 0, 1f);
        resourcesScript = resources.GetComponent<Resources>();
    }

    void FixedUpdate()
    {
        // Display bar values
        oxygenBar.value = oxygen;
        healthBar.value = health;
        wasteBar.value = waste;
        carbonDioxydeBar.value = carbonDioxyde;
        massBar.value = mass;

    }

    void UpdateStats()
    {
        food -= 1;
        if (food < 100)
            food += resourcesScript.TakeFood(2);
        oxygen -= 1;

        if (food > 0)
            waste++;
        if (food > 70)
            mass++;
        if (food < 20)
        {
            mass--;
            health--;
        }

        if (oxygen > 0)
            carbonDioxyde++;
        if (oxygen <= 0)
            health-= 10;
        if (carbonDioxyde >= 90)
            health -= 5;

        oxygen = Mathf.Clamp(oxygen, 0, 100);
        food = Mathf.Clamp(food, 0, 100);
        mass = Mathf.Clamp(mass, 0, 100);
        health = Mathf.Clamp(health, 0, 100);
        waste = Mathf.Clamp(waste, 0, 100);
        carbonDioxyde = Mathf.Clamp(carbonDioxyde, 0, 100);
    }
}
