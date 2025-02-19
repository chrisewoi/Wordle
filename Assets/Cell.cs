using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    public TMP_Text UIField;

    void Start()
    {
        UIField = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnInputFieldValueChanged()
    {
       UIField.text = UIField.text.ToUpper();
    }

    public string GetLetter()
    {
        return UIField.text;
    }
}
