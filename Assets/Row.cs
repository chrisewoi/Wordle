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
