using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class fim : MonoBehaviour
{
    [SerializeField] CanvasGroup canvas1;
    [SerializeField] CanvasGroup canvas2;
    [SerializeField] float tempo1 = 1f;
    [SerializeField] float tempo2 = 2f;
    [SerializeField] float intensidade = 0.3f;
    private bool fade1 = false;
    private bool fade2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas1.alpha = 0;
        canvas2.alpha = 0;
        StartCoroutine(fade());
    }

    // Update is called once per frame
    void Update()
    {
        if (fade1)
        {
            canvas1.alpha += intensidade * Time.deltaTime;
        }
        if (fade2)
        {
            canvas2.alpha += intensidade * Time.deltaTime;
        }
    }
    
    IEnumerator fade()
    {
        yield return new WaitForSeconds(tempo1);
        fade1 = true;
        yield return new WaitForSeconds(tempo2);
        fade2 = true;
    }
}
