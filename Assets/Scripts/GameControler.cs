using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lvls = new GameObject[3];

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    [SerializeField]
    private GameObject tutorial;

    

    [SerializeField]
    private GameObject finalScreen;

    private int currentLvl = 0;

    [SerializeField]
    private GameObject audioTuto;


    public float timmer;


    private bool startGame = false;

    private void Awake()
    {
        ShuffleQuestions();
    }

    private void Start()
    {
        pacocaAnim = pacoca.GetComponent<Animator>();

    }


    private void Update()
    {
        if (startGame == true)
        {
            timmer += Time.deltaTime;
        }

    }

    public void CloseTutoAndStart() //FECHA TUTORIAL E INICIA GAME
    {
        tutorial.SetActive(false);
        StartCoroutine(AudioTutorial());
    }

    IEnumerator AudioTutorial()
    {
        audioTuto.SetActive(true);

        yield return new WaitForSeconds(31f);
        audioTuto.SetActive(false);

        StartTurn();
    }

    private void StartTurn() //INICIA TURNO
    {
        startGame = true;

        lvls[currentLvl].SetActive(true);

    }


    public void RhymeComplete()
    {

        lvls[currentLvl].SetActive(false);

        if (currentLvl >= 2)
        {
            startGame = false;

            finalScreen.SetActive(true);
        }
        else
        {
            currentLvl++;
            lvls[currentLvl].SetActive(true);
        }
    }


    private void ShuffleQuestions()     //EMBARALHAR FRASES
    {
        for (int i = 0; i < lvls.Length; i++)
        {
            GameObject obj = lvls[i];
            int randomizeArray = Random.Range(0, i);
            lvls[i] = lvls[randomizeArray];
            lvls[randomizeArray] = obj;
        }
    }




}
