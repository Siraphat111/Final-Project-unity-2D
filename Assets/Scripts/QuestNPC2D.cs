using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestNPC2D : MonoBehaviour
{
    public enum QuestState { NotStarted, InProgress, ReadyToTurnIn }
    public QuestState currentState = QuestState.NotStarted;

    [Header("Quest Settings")]
    public string questTitle = "Backyard Search";
    public int targetAmount = 1;
    private int currentAmount = 0;

    [Header("NPC Dialogue UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    [Header("Quest Window UI")]
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI objectiveText;

    private bool isPlayerNear = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
        UpdateQuestWindowUI();
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            HandleDialogue();
        }
    }

    void HandleDialogue()
    {
        dialoguePanel.SetActive(true);

        if (currentState == QuestState.NotStarted)
        {
            dialogueText.text = $"Quest Accepted! Go find {targetAmount} item in the backyard.";
            currentState = QuestState.InProgress;
            UpdateQuestWindowUI();
        }
        else if (currentState == QuestState.InProgress)
        {
            dialogueText.text = $"Still missing! Check the backyard ({currentAmount}/{targetAmount})";
        }
        else if (currentState == QuestState.ReadyToTurnIn)
        {
            if (!dialogueText.text.Contains("found it"))
            {
                dialogueText.text = "You found it in the backyard! Thank you! (Press E to restart)";
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddQuestProgress(int amount)
    {
        if (currentState != QuestState.InProgress) return;

        currentAmount = Mathf.Min(currentAmount + amount, targetAmount);
        if (currentAmount >= targetAmount)
        {
            currentState = QuestState.ReadyToTurnIn;
        }
        UpdateQuestWindowUI();
    }

    void UpdateQuestWindowUI()
    {
        if (currentState == QuestState.NotStarted)
        {
            questNameText.text = "No Quest";
            objectiveText.text = "- Talk to NPC";
        }
        else if (currentState == QuestState.InProgress)
        {
            questNameText.text = questTitle;
            objectiveText.text = $"- Backyard ({currentAmount}/{targetAmount})";
        }
        else if (currentState == QuestState.ReadyToTurnIn)
        {
            questNameText.text = "Quest Done!";
            objectiveText.text = "- Talk to NPC";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            dialoguePanel.SetActive(true);

            if (currentState == QuestState.NotStarted)
            {
                dialogueText.text = $"Can you help me find {targetAmount} item in the backyard? (Press E)";
            }
            else if (currentState == QuestState.InProgress)
            {
                dialogueText.text = $"Still missing! Check the backyard ({currentAmount}/{targetAmount})";
            }
            else if (currentState == QuestState.ReadyToTurnIn)
            {
                dialogueText.text = "You found it in the backyard! Thank you! (Press E to restart)";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialoguePanel.SetActive(false);
        }
    }
}
