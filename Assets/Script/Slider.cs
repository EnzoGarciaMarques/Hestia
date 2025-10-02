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
            sensivity.instance.sense = v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
