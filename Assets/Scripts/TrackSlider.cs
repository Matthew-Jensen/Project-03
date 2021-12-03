using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = slider.value.ToString();
    }
}
