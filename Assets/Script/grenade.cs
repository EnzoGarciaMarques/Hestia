using UnityEngine;

public class grenade : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    [SerializeField] float force;
    private float timer;
    [SerializeField] Vector3 radius;
    [SerializeField] float dano;
    [SerializeField] AudioClip explode;
    [SerializeField] ParticleSystem ps;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector3(direction.x, direction.y, direction.z).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Explode()
    {

        //Instantiate(explosion, transform.position, transform.rotation);
        ps.Play();
        SFXManager.Instance.PlaySoundFXClip(explode, transform, 1f);
        Collider[] colliders = Physics.OverlapBox(transform.position, radius);
        foreach (Collider player in colliders)
        {
            PlayerHealth damage = player.transform.GetComponent<PlayerHealth>();
            if (damage != null)
            {
                damage.DamageTaken(dano);
            }
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dano = 3;
            Explode();
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            dano = 2;
            Explode();
        }
    }
}
