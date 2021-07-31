using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Conversation conversation;

    public FamiliarStats familiar;

    public GameObject dialogueBox;
    public GameObject questionBox;

    public Text speaker;
    public Text dialogue;
    public Text Choice1;
    public Text Choice2;

    private int lineIndex = 0;

    private bool inDialogue;

    private void Awake()
    {
        //Make this a singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inDialogue)
        {
            AdvanceConversation();
        }
    }

    public void StartConversation(Conversation convo)
    {
        conversation = convo;

        //Open Dialogue Box
        dialogueBox.SetActive(true);

        AdvanceConversation();
        inDialogue = true;
    }

    public void AdvanceConversation()
    {
        //Pause the game
        Time.timeScale = 0;

        if (lineIndex < conversation.lines.Length)
        {
            DisplayLine();
            inDialogue = true;
            lineIndex++;
        }
        else if(conversation.question != null)
        {
            DisplayQuestion();
            
            //Reset Dialogue
            lineIndex = 0;
            inDialogue = false;
        }
        else if (conversation.sceneChange)
        {
            SceneManager.LoadScene(conversation.scene);
        }
        else
        {
            //Reset Dialogue
            lineIndex = 0;
            inDialogue = false;

            //Unpause the game
            Time.timeScale = 1;

            //Close dialogue
            dialogueBox.SetActive(false);
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[lineIndex];

        SetDialogue(line.character, line.text, line.color);
    }

    void DisplayQuestion()
    {
        SetDialogue(conversation.question.character, conversation.question.text, conversation.question.color);

        questionBox.SetActive(true);
        Choice1.text = conversation.question.choices[0].text;
        Choice2.text = conversation.question.choices[1].text;
    }

    void SetDialogue(string active, string text, Color col)
    {
        speaker.text = active;
        dialogue.text = text;
        dialogue.color = col;
    }

    public void ChoiceOne()
    {
        familiar.ChangeBond(conversation.question.choices[0].familiarBond);

        dialogueBox.SetActive(false);
        questionBox.SetActive(false);

        if (conversation.question.choices[0].conversation != null)
        {
            StartConversation(conversation.question.choices[0].conversation);
        }
    }

    public void ChoiceTwo()
    {
        familiar.ChangeBond(conversation.question.choices[1].familiarBond);

        dialogueBox.SetActive(false);
        questionBox.SetActive(false);

        if (conversation.question.choices[1].conversation != null)
        {
            StartConversation(conversation.question.choices[1].conversation);
        }
    }
}