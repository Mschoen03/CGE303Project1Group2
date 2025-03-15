using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;


public class DialogManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject ContinueButton;
    public GameObject dialogPanel;

    void OnEnable()
    {
        ContinueButton.SetActive(false);
        StartCoroutine(Type());

    }

    IEnumerator Type()
    {
        textbox.text = "";
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        ContinueButton.SetActive(true);
    }

    public void NextSentence()
    {
        ContinueButton.SetActive(false);
        if (index < sentences.Length -1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textbox.text = "";
            dialogPanel.SetActive(false);
        }
    }
     
}
