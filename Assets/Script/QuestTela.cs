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
        if (!Quests.instance.firstTime && !Quests.instance.getQuest && !Quests.instance.rescue)
        {
            chat.text = "Entre no espelho e explore o reino";
        }
        if (Quests.instance.getQuest && !Quests.instance.questCompleted && Quests.instance.rescue)
        {
            chat.text = "Pegue 5 cenouras para Coelha Possui " + Quests.instance.carrots.ToString();
        }
        if (!Quests.instance.getQuest && !Quests.instance.questCompleted && Quests.instance.rescue)
        {
            chat.text = "Fale com a coelha na cozinha";
        }
        if (Quests.instance.questCompleted)
        {
            chat.text = "";
        }

    }
}
