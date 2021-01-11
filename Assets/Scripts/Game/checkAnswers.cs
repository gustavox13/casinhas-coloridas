using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAnswers : MonoBehaviour
{


    public bool completeChallenge = false;
    private int numWord = 0;

    [SerializeField]
    private GameObject gamecontroller;

    [SerializeField]
    private AudioSource pointAudio;

    [SerializeField]
    private AudioSource completeAudio;

    //TAGS CORRETAS
    [SerializeField]
    private string firstword;
    [SerializeField]
    private string secondWord;



    //OBJ DA PERGUNTA ATUAL
    [SerializeField]
    private GameObject emptySlot1;
    [SerializeField]
    private GameObject fullSlot1;

    [SerializeField]
    private GameObject emptySlot2;
    [SerializeField]
    private GameObject fullSlot2;

    [SerializeField]
    private float timeAudio;

    private bool audioFinish = false;



    private void Start()
    {
        StartCoroutine(ListenAudio());
    }




    IEnumerator ListenAudio()
    {
        yield return new WaitForSeconds(timeAudio);

        audioFinish = true;

        AudioFinishAndRhymeComplete();
    }


    private void AudioFinishAndRhymeComplete()
    {
        if(numWord == 2 && audioFinish == true)
        {
            StartCoroutine(ListencompleteAudio());
        }
    }

    IEnumerator ListencompleteAudio()
    {
        completeAudio.Play();
        //REPRODUZ O AUDIO COMPLETO AQUI

        yield return new WaitForSeconds(timeAudio + 2.7f); //TEMPO DE REPRODUZIR O AUDIO COMPLETO

        gamecontroller.GetComponent<GameControler>().RhymeComplete(); //LEVA ATE O SCRIPT GAMECONTROLER E FINALIZA O LVL
    }
    

    public void checkCurrentWord(string currentWord)
    {
        numWord++;

        if(currentWord == firstword)
        {
            emptySlot1.SetActive(false);
            fullSlot1.SetActive(true);



        } else if(currentWord == secondWord)
        {
            emptySlot2.SetActive(false);
            fullSlot2.SetActive(true);
        }


         if (numWord == 2)
         {
            pointAudio.Play();
         }

        AudioFinishAndRhymeComplete();

    }





}
