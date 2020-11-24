using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

    void Start ()
    {
        max += 1;
        NextGuess();
    }

    public void NumIsHigher()
    {
        min = guess + 1;
        NextGuess();
    }

    public void NumIsLower()
    {
        max = guess;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max);
        if (guess >= max) guess = max-1;
        guessText.text = guess.ToString();
    }

}
