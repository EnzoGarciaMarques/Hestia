using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject revolver;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject sword;
    [SerializeField] Animator armas;
    public float weapon;

    public static WeaponManager instance;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        armas.SetInteger("arma", (int)weapon);
        if (weapon == 1)
        {
            revolver.gameObject.SetActive(true);
            shotgun.gameObject.SetActive(false);
            sword.gameObject.SetActive(false);
            
        }
        else if (weapon == 2)
        {
            shotgun.gameObject.SetActive(true);
            revolver.gameObject.SetActive(false);
            sword.gameObject.SetActive(false);
        }
        else if(weapon == 3)
        {
            sword.gameObject.SetActive(true);
            revolver.gameObject.SetActive(false);
            shotgun.gameObject.SetActive(false);
        }
        else
        {
            revolver.gameObject.SetActive(false);
            shotgun.gameObject.SetActive(false);
            sword.gameObject.SetActive(false);
            
        }
        if (weapon == 0)
        {
            armas.gameObject.SetActive(false);
        }
        else 
        {
            armas.gameObject.SetActive(true);
        }

    }

}
