using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    
    [SerializeField] Slider slide;
    void Start()
    {
        slide.onValueChanged.AddListener((v) =>
        {
            v = sensivity.instance.sense;
        });
    }

    // Update is called once per frame
    void Update()
    {
        slide.onValueChanged.AddListener((v) =>
        {
            sensivity.instance.sense = v;
        });
    }
}
