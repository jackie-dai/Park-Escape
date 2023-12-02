using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Hangman : MonoBehaviour
{
    #region Variables
    private char userGuess = '\0';
    private string[] words = { "late", "life", "death" };
    private char[] keyword;
    private char[] userWord;
    [SerializeField] 
    private TMP_InputField userInput;
    [SerializeField]
    private TextMeshProUGUI keyword_UI;
    [SerializeField]
    private Canvas inputCanvas;
    private bool guessed = false;
    private int correctCounter = 0;
    private char[] guessedLetters;
    private int totalGuessesRemaining;
    private int guessesRemaining;
    [SerializeField]
    private GameObject doll;
    private Rope rope;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        rope = doll.transform.GetComponent<Rope>();
        StartNewGame();
    }

    private void StartNewGame()
    {
        System.Random rand = new System.Random();
        keyword = words[rand.Next(words.Length)].ToCharArray();
        Debug.Log("Keyword: " + keyword[0]);

        userWord = new char[keyword.Length * 2];
        
        guessed = false;
        userGuess = '\0';
        totalGuessesRemaining = keyword.Length;
        guessesRemaining = 5;
        guessedLetters = new char[guessesRemaining];
        FillArrayWith_(userWord);
    }


    private void Update()
    {

        WaitForGuess();
        keyword_UI.text = new string(userWord);
    }

    private void WaitForGuess()
    {
        if (guessed)
        {
            Debug.Log("recieved " + userGuess);
            guessed = false;
            CheckUserGuess(userGuess);
        } else
        {
            Debug.Log("Waiting for guess");
        }  
     
    }

    private void CheckUserGuess(char guess)
    {
        int indexOfGuess = isLetterInWord(guess, keyword);
        if (indexOfGuess >= 0) 
        {
            totalGuessesRemaining -= 1;
            userWord[indexOfGuess * 2] = guess;
            correctCounter += 1;
            if (correctCounter >= keyword.Length)
            {
                Win();

            }
            Debug.Log("Nice guess! you need " + (keyword.Length - correctCounter) + " more letters!");
            Debug.Log("Current User Word: " + new string(userWord));
        } else
        {
            Debug.Log("why must you so stupid");
            guessesRemaining -= 1;
            rope.MoveDown();
            if (guessesRemaining <= 0)
            {
                Debug.Log("You suck");
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }

    public void SubmitLetter()
    {
        userGuess = userInput.text[0];
        Debug.Log("receieved : " + userGuess);
        if (userGuess != '\0' && isLetterInWord(userGuess, guessedLetters) < 0)
        {
            
            guessedLetters[guessedLetters.Length - totalGuessesRemaining] = userGuess;
           
            guessed = true;
        }
        else
        {
            Debug.Log("Invalid entry!");
        }
    }

    // Returns index location of letter in word. -1 otherwise.
    private int isLetterInWord(char letter, char[] word)
    {
        for (int index = 0; index < word.Length; index++)
        {
            if (letter == word[index])
            {
                return index;
            }
        }
        return -1;
    }

    private void FillArrayWith_(char[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = '_';
            } else
            {
                arr[i] = ' ';
            }
        }
    }

   private void Win()
    {
        Debug.Log("WINNER CHICKEN DINNER DINNER");
        SceneManager.LoadScene("Jackie");
    }
}
