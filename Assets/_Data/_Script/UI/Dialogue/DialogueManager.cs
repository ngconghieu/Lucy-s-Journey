using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text name;
    public Text conv;
    private Queue<string> sentences;
    public static DialogueManager instance;
   
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Staring conv with "+ dialogue.name);
        name.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) 
        { sentences.Enqueue(sentence); }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        conv.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            conv.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        Debug.Log("Ket thuc tro chuyen");
        SceneManager.LoadSceneAsync(2);
    }
    public void skip()
    {
        SceneManager.LoadSceneAsync(2);
    }

}
