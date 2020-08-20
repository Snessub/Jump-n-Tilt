﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Author: Michelle Limbach
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    private Queue<string> sentences;
    private Queue<string> names;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public GameObject kashima;
    //public GameObject onamazu;
    private GameObject[] dialogueImages;
    public Animator animator;
    private GameObject currentActiveImage;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        sentences.Clear();
        names.Clear();
        Time.timeScale = 0f;
        if(dialogue.images.Length > 3)
        {
            Debug.Log("Bitte nicht mehr als 3 Bilder in den Dialoge laden!");
            EndDialogue();
            return;
        }
        dialogueImages = new GameObject[dialogue.images.Length];
        foreach (GameObject image in dialogue.images)
        {
            switch (image.name)
            {
                case "Kashima":
                    dialogueImages[0] = image;
                    break;
                case "Onamazu":
                    dialogueImages[1] = image;
                    break;
                case "Kitsune":
                    dialogueImages[2] = image;
                    break;
            }
        }
        foreach(GameObject image in dialogueImages)
        {
            image.SetActive(false);
        }
        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSectence();
    }

    public void DisplayNextSectence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if(currentActiveImage != null)
        {
            currentActiveImage.SetActive(false);
        }
        switch (name)
        {
            case "Kashima":
                dialogueImages[0].SetActive(true);
                currentActiveImage = dialogueImages[0];
                break;
            case "Onamazu":
                dialogueImages[1].SetActive(true);
                currentActiveImage = dialogueImages[1];
                break;
            case "Kitsune":
                dialogueImages[2].SetActive(true);
                currentActiveImage = dialogueImages[2];
                break;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Time.timeScale = 1f;
        animator.SetBool("isOpen", false);
        if (currentActiveImage != null)
        {
            currentActiveImage.SetActive(false);
        }
    }

}
