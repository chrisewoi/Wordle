using UnityEngine;

public class Game : MonoBehaviour
{
    public string word = "HAPPY";
    //public string guess = "PPYHA";

    public Row activeRow;
    public Row[] rows;
    public int activeIndex;
    public int activeIndexProperty
    {
        get
        {
            return activeIndex;
        }
        set
        {
            activeIndex = Mathf.Clamp(value, 0, rows.Length - 1);
            activeRow = rows[activeIndex];
            foreach(Row row in rows) 
                row.SetState(false);
            activeRow.SetState(true);
        }
    }

    public Color hot, warm, cold;

    public bool gameRunning = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GuessWord();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GuessWord();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                UINavigation.GetPrevious();
            else 
                UINavigation.GetNext();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
            UINavigation.GetPrevious();
    }

    public void GuessWord()
    {
        if (!gameRunning) return;


        string guess = activeRow.GetWord();
        if (guess.Length != 5)
        {
            return;
        }
        print($"Comparing the word {word} with the word {guess}");

        for (int i = 0; i < 5; i++)
        {
            print($"Comparing {word[i]} against {guess[i]}");
            if (word[i] == guess[i])
                //print($"<color=green>They match!</color>");
                activeRow.PushColor(i, hot);
            else if (word.Contains(guess[i]))
                //print($"<color=orange> The word contains the letter {guess[i]}</color>");
                activeRow.PushColor(i, warm);
            else
                //print($"<color=red> The word doesn't contain the letter {guess[i]}</color>");
                activeRow.PushColor(i, cold);
        }

        if (guess == word)
        {
            print("You saw my whole word!");
            gameRunning = false;
            activeRow.SetState(false);
            foreach (Cell cell in activeRow.cells)
                cell.textField.readOnly = true;
            return;
        }

        if (activeIndexProperty >= rows.Length-1)
        {
            print("You didn't do it heheee!");
            gameRunning = false;
            activeRow.SetState(false);
            return;
        }

        activeIndexProperty += 1;
        UINavigation.SelectCell(activeRow.cells[0]);
    }
}
