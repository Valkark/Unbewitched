using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiagnosticsPrototype : MonoBehaviour
{
    public string firstPot;
    public string secondPot;

    public GameObject[] monsters;
    public GameObject[] humans;

    public string rightSolution;
    public string result;

    public static bool[] sucess = new bool[3];
    public static int i = 0 ;

    public AudioSource audioSource;
    public AudioClip audioClipSucess;
    public AudioClip audioClipFail;

    void Start()
    {
        if (DiagnosticSceneInformation.monsterType == BodyPartOrigin.Frog)
        {
            monsters[0].SetActive(true);
            rightSolution = "85";// 8 + 5
        }
        else if (DiagnosticSceneInformation.monsterType == BodyPartOrigin.Horse)
        {
            monsters[1].SetActive(true);
            rightSolution = "94";// 9 + 4
        }
        else
        {
            monsters[2].SetActive(true);
            rightSolution = "113";// 1 + 13
        }
    }

    public void FirstCombination(string index)
    {
        firstPot = index;
    }

    public void SecondCombination(string index)
    {
        secondPot = index;
        FinalResult();
    }

    public void FinalResult()
    {
        result = firstPot + secondPot;
        if (result == rightSolution)
        {
            humans[i].SetActive(true);
            sucess[i] = true;
            monsters[i].SetActive(false);
            audioSource.PlayOneShot(audioClipSucess);
        }
        else
        {
            sucess[i] = false;
            audioSource.PlayOneShot(audioClipFail);
        }
        StartCoroutine(GoBack());
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1); //Scene 2 is Diagnostics
    }
}
