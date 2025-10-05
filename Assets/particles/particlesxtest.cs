using UnityEngine;

public class particlesxtest : MonoBehaviour
{
    [SerializeField]ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ps.Play();
        }
    }
}
