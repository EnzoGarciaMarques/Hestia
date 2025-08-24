using UnityEngine;

public class Quests : MonoBehaviour
{
    public bool rescue = false;
    public bool getQuest = false;
    public bool questCompleted = false;
    public int carrots;
    public bool firstTime = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carrots >= 3 && getQuest == true)
        {
            questCompleted = true;
        }
    }
}
