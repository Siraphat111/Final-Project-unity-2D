using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    public string questID;
    public string questName;
    public string questDescription;
    public List<QuestObjective> objectives;

    private void OnEnable()
    {    
        if (string.IsNullOrEmpty(questID))
        {
            questID = questName + "_" + System.Guid.NewGuid().ToString();
        }
    }

    [System.Serializable]
    public class QuestObjective
    {
        public string objectiveID;
        public string description;
        public ObjectiveType type;
        public int requiredAmount;
        public int CurrentAmount;  

        public bool IscomCompleted => CurrentAmount >= requiredAmount;
    }

    public enum ObjectiveType { CollectItem, DefeatEnemy, ExploreArea }

    [System.Serializable]

    public class QuestProgress
    {
        public Quest quest;
        public List<QuestObjective> objective;

        public QuestProgress(Quest quest)
        {
            this.quest = quest;
            this.objective = new List<QuestObjective>();

            foreach (var obj in quest.objectives)
            {
                this.objective.Add(new QuestObjective
                {
                    objectiveID = obj.objectiveID,
                    description = obj.description,
                    type = obj.type,
                    requiredAmount = obj.requiredAmount,
                    CurrentAmount = 0
                });
            }
        }

        public bool IsCompleted => objective.TrueForAll(obj => obj.IscomCompleted);

        public string QuestID => quest.questID; 
    }
}
