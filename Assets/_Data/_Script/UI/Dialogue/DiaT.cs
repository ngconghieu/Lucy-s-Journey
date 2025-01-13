using UnityEngine;

public class DiaT : MonoBehaviour
{
    public Dialogue dialogue;


    public void TD()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
