using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardController : MonoBehaviour {

    private GameLogic gameLogic;
    public Text nbrText, introText;
    public Button btnStartEnd, btnLower, btnHigher, btnEqual;
    public GameObject nbrGuess;

    // Use this for initialization
    void Start () {
        
        gameLogic = new GameLogic();
        nbrGuess.SetActive(false);
    }

    public void NumberHigher()
    {
        gameLogic.AdaptMin();
        nbrText.text = gameLogic.GetGuess();
    }

    public void NumberLower()
    {
        gameLogic.AdaptMax();
        nbrText.text = gameLogic.GetGuess();
    }

    public void NumberEqual()
    {
        nbrGuess.SetActive(false);
        introText.text = gameLogic.GetGuess()+ "! Right? I totally read your mind~ " + 
            "So, up for another round?";
        introText.enabled = true;
        btnStartEnd.GetComponentInChildren<Text>().text = "Start Game";
        btnHigher.enabled = false;
        btnLower.enabled = false;
        btnEqual.enabled = false;
        
    }

    public void StartGame()
    {
        gameLogic.StartGame();
        nbrText.text = gameLogic.GetGuess();
        introText.enabled = false;
        btnStartEnd.GetComponentInChildren<Text>().text = "Again!";
        btnStartEnd.GetComponent<Image>().color = Color.yellow;
        nbrGuess.SetActive(true);
        btnHigher.enabled = true;
        btnLower.enabled = true;
        btnEqual.enabled = true;
    }

    public void EndGame()
    {
        nbrGuess.SetActive(false);
        introText.enabled = true;
        btnStartEnd.GetComponentInChildren<Text>().text = "Start Game";
    }
}
