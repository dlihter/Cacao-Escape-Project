using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuessNumber : MonoBehaviour
{
    int max;
    int min;
    int guess;
    int maxGuessesAllowed = 10;

    public Text guessText;
    public Text countText;

	// Use this for initialization
	void Start ()
    {
        StartGame();
	}

    // Here we initialize start values
    public void StartGame()
    {
        min = 1;
        max = 1000;
        NextGuess();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    // Here we are doing random calculations for guessing numbers. Numbers are picked randomly from certain range which is narrower with every guess attempt. Also, if number of guesses reaches 0 next scene is loaded
    public void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
        maxGuessesAllowed--;
        countText.text = maxGuessesAllowed.ToString();
        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene(4);
        }

    }
}
