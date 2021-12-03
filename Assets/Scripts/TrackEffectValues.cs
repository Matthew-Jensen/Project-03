using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackEffectValues : MonoBehaviour
{
    [SerializeField] GameObject subsm;
    float x, y;
    string z, z_actual;

    // Start is called before the first frame update
    void Start()
    {
        x = subsm.transform.Find("Slider_Magnitude").GetComponent<Slider>().value;
        y = subsm.transform.Find("Slider_Duration").GetComponent<Slider>().value;
        z = subsm.transform.Find("RangeBtn").GetComponentInChildren<Text>().text;
        z_actual = z.Remove(0, 59);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateValues()
    {
        x = subsm.transform.Find("Slider_Magnitude").GetComponent<Slider>().value;
        y = subsm.transform.Find("Slider_Duration").GetComponent<Slider>().value;
        z = subsm.transform.Find("RangeBtn").GetComponentInChildren<Text>().text;
        z_actual = z.Remove(0, 59);

        this.gameObject.GetComponent<Text>().text = x + " pts for " + y + " secs on " + z_actual;
    }

    public void UpdateValues_FT()
    {
        x = subsm.transform.Find("Slider_Magnitude").GetComponent<Slider>().value;
        y = subsm.transform.Find("Slider_Duration").GetComponent<Slider>().value;
        z = subsm.transform.Find("RangeBtn").GetComponentInChildren<Text>().text;
        z_actual = z.Remove(0, 59);

        this.gameObject.GetComponent<Text>().text = x + " ft for " + y + " secs on " + z_actual;
    }

    public void UpdateDurationOnly()
    {
        y = subsm.transform.Find("Slider_Duration").GetComponent<Slider>().value;
        this.gameObject.GetComponent<Text>().text = " for " + y + " secs ";
    }

    public void UpdateDurationTarget()
    {
        y = subsm.transform.Find("Slider_Duration").GetComponent<Slider>().value;
        z = subsm.transform.Find("RangeBtn").GetComponentInChildren<Text>().text;
        z_actual = z.Remove(0, 59);
        this.gameObject.GetComponent<Text>().text = " for " + y + " secs on " + z_actual;
    }
}
