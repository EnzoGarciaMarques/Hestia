using TMPro;
using UnityEngine;

public class QuestTela : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Quests.instance.firstTime && !Quests.instance.getQuest)
        {
            chat.text = "";
        }
        if (Quests.instance.getQuest && !Quests.instance.questCompleted)
        {
            chat.text = "Pegue 5 cenouras para Coelha Possui " + Quests.instance.carrots.ToString();
        }
        if (Quests.instance.questCompleted)
        {
            chat.text = "";
        }

    }
}
