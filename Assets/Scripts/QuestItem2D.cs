using UnityEngine;

public class QuestItem2D : MonoBehaviour
{
    public QuestNPC2D questNPC;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && questNPC.currentState == QuestNPC2D.QuestState.InProgress)
        {
            questNPC.AddQuestProgress(1);
            Destroy(gameObject, 0.05f);
        }
    }
}
