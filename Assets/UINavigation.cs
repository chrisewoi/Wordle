using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour
{
    public static EventSystem system;


    void Awake()
    {
        system = GameObject.FindAnyObjectByType<EventSystem>();
    }

    public static void GetNext()
    {
        Selectable nextCell = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();

        if(nextCell != null)
        {
            system.SetSelectedGameObject(nextCell.gameObject);
        }

        
    }

    public static void GetPrevious()
    {
        Selectable previousCell = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft();

        if (previousCell != null)
        {
            system.SetSelectedGameObject(previousCell.gameObject);
        }
    }

    public static void SelectCell(Cell cell)
    {
        if (cell.GetComponent<Selectable>() != null)
        {
            system.SetSelectedGameObject(cell.gameObject);
        }
    }
}
