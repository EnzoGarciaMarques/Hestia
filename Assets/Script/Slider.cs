using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    [SerializeField] sensivity sense;
    [SerializeField] Slider slide;
    void Start()
    {
        slide.onValueChanged.AddListener((v) =>
        {
            sense.sense = v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
