using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Transform camTransform;


    public float shakeDuration = 0f;

    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;
    [SerializeField] Animator life;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject music;
    [SerializeField] GameObject sfx;
    [SerializeField] GameObject sound;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        originalPos = camTransform.localPosition;
    }
    private void Update()
    {
        if (health > 6)
        {
            health = 6;
        }
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
        life.SetInteger("vida", (int)health);
    }
    public void DamageTaken(float amount)
    {
        health -= amount;
        Debug.Log("tomou");
        shakeDuration = 1;

        if (health <= 0)
        {
            Dead();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            DamageTaken(1);
        }
        if (other.gameObject.CompareTag("EnemySlash"))
        {
            DamageTaken(2);
        }
    } 

    public void Dead()
    {
        StartCoroutine(Morto());
    }

    IEnumerator Morto()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Destroy(canvas);
        Destroy(sound);
        Destroy(sfx);
        Destroy(music);

        SceneManager.LoadScene("casa");
    }

}
