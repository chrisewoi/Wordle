using UnityEngine;

public class Row : MonoBehaviour
{
    public Cell[] cells;


    private void Awake()
    {
        cells = GetComponentsInChildren<Cell>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushColor(int index, Color newColor)
    {
        cells[index].PushColor(newColor);
    }

    public void SetState(bool state)
    {
        foreach (Cell cell in cells)
        {
            cell.SetState(state);
        }
    }

    public string GetWord()
    {
        string word = "";
        foreach (Cell cell in cells)
        {
            word += cell.GetLetter();
        }

        return word;
    }
}
