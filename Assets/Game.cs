using UnityEngine;

public class Game : MonoBehaviour
{
    public string word = "HAPPY";
    //public string guess = "PPYHA";

    public Row activeRow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GuessWord();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GuessWord();
        }
    }

    public void GuessWord()
    {
        string guess = activeRow.GetWord();
        print($"Comparing the word {word} with the word {guess}");

        for (int i = 0; i < 5; i++)
        {
            print($"Comparing {word[i]} against {guess[i]}");
            if (word[i] == guess[i])
                print($"<color=green>They match!</color>");
            else if (word.Contains(guess[i]))
                print($"<color=orange> The word contains the letter {guess[i]}</color>");
            else
                print($"<color=red> The word doesn't contain the letter {guess[i]}</color>");
        }
    }
}
