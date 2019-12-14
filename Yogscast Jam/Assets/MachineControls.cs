using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineControls : MonoBehaviour
{

    public Button produce;
    public Button recycle;
    public Button remove;
    public Resources resources;

    // Start is called before the first frame update
    void Start()
    {
        produce = produce.GetComponent<Button>();
        recycle = recycle.GetComponent<Button>();
        remove = remove.GetComponent<Button>();
        resources = resources.GetComponent<Resources>();

        produce.onClick.AddListener(Produce);
        recycle.onClick.AddListener(Recycle);
        remove.onClick.AddListener(Remove);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Produce()
    {
        
        StartCoroutine(ProduceCoroutine());
    }

    IEnumerator ProduceCoroutine()
    {
        recycle.interactable = false;
        remove.interactable = false;

        Color originColor = produce.GetComponent<Image>().color;
        produce.GetComponentInChildren<Text>().text = "Producing nutrients...";
        produce.GetComponent<Image>().color = Color.red;

        yield return new WaitForSeconds(Random.Range(5f, 10f));

        if (resources.TakeElectricity(Random.Range(20f, 25f)) > 0)
            resources.TakeFood(Random.Range(-10f, -15f));

        produce.GetComponentInChildren<Text>().text = "Produce food";
        produce.GetComponent<Image>().color = originColor;

        recycle.interactable = true;
        remove.interactable = true;
    }

    void Recycle()
    {
        StartCoroutine(RecycleCoroutine());
    }

    IEnumerator RecycleCoroutine()
    {
        produce.interactable = false;
        remove.interactable = false;

        Color originColor = produce.GetComponent<Image>().color;
        recycle.GetComponentInChildren<Text>().text = "Recycling waste...";
        recycle.GetComponent<Image>().color = Color.red;

        yield return new WaitForSeconds(Random.Range(3f, 7f));

        float wasteTaken = resources.TakeWaste(30f);
        print(wasteTaken);

        if (resources.TakeElectricity(Random.Range(5f, 10f)) > 0 && wasteTaken > 0)
            resources.TakeFood(Random.Range(-15f, -20f));

        recycle.GetComponentInChildren<Text>().text = "Recycle waste";
        recycle.GetComponent<Image>().color = originColor;

        produce.interactable = true;
        remove.interactable = true;
    }

    void Remove()
    {
        StartCoroutine(RemoveCoroutine());
    }

    IEnumerator RemoveCoroutine()
    {
        yield return null;
    }
}
