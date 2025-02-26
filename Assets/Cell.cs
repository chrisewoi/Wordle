using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    public TMP_InputField textField;

    void Start()
    {

    }

    void Awake()
    {
        textField = GetComponent<TMP_InputField>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnInputFieldValueChanged()
    {
       textField.text = textField.text.ToUpper();
    }

    public void PushColor(Color newColor)
    {
        GetComponentInChildren<TMP_Text>().color = newColor;
    }

    public string GetLetter()
    {
        return textField.text;
    }

    public void ValidateCell()
    {
        // is the cell empty?
        if (textField.text.Length <= 0)
            return;

        //is the cell more than 1 character?
        if (textField.text.Length > 1)
            {
                textField.text = textField.text[0].ToString();
                return;
            }

        // does the cell contain anything that's not a letter?
        if (!char.IsLetter(textField.text[0]))
        {
            textField.text = "";
            return;
        }


        // is the cell not a capital?

        if (char.IsLower(textField.text[0]))
        {
            textField.text = textField.text.ToUpper();
            return;
        }

        UINavigation.GetNext();
    }


    public void SetState(bool state)
    {
        textField.interactable = state;
    }
}