using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject revolver;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject sword;
    public float weapon;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
