using UnityEngine;

public class Interactable_Dialogue : MonoBehaviour, IInteractable
{

    [Header("Message")]
    [SerializeField] private string message;

    [SerializeField] private UIManager uiManager;

    [SerializeField] private string[] _dialogue;
    private int dialogueIndex = 0;
    private bool showingDialogue = false;


    private void Awake()
    {
        uiManager = ServiceHub.Instance.UIManager;

        if (uiManager == null) Debug.LogError("UIManager not found in ServiceHub. Please ensure it is properly set up.");
    }


    public void Interact()
    {
        if (showingDialogue) dialogueIndex += 1;
        showingDialogue = true;

        if (dialogueIndex >= _dialogue.Length) 
        {
            dialogueIndex = 0;
            showingDialogue = false;
            uiManager.HideDialoguePanel();
            return;
        }

        uiManager.SetDialogue(_dialogue[dialogueIndex], this);  
        
    }

}
