using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] float timePeriod = 0;
    [SerializeField] Sprite sprite;
    float counter = 0;
    Sprite changer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + 1*Time.deltaTime;
        if (counter >= timePeriod)
        {
            changer = GetComponent<Image>().sprite;
            GetComponent<Image>().sprite = sprite;
            sprite = changer;
            counter = 0;
        }
    }
}
