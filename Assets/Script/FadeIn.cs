using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup textos;
    private bool fade = false;
    [SerializeField] float intesidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fade = true;
    }

    // Update is called once per frame
    void Update()
    {
        
            textos.alpha += Time.deltaTime * intesidade;
        
    }
}
