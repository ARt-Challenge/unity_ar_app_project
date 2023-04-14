using UnityEngine;
using UnityEngine.UI;

public class UIController2 : MonoBehaviour
{
    public Button unhideButton;
    public GameObject[] uiElements;
    public GameObject uiElementTohide;

    void Start()
    {
        unhideButton.onClick.AddListener(UnhideAllUIElements);
    }

    void UnhideAllUIElements()
    {
        foreach (GameObject uiElement in uiElements)
        {   
            // Unhides all UI element exept specific
            if (uiElement != uiElementTohide)
            {
                uiElement.SetActive(true);
            }
        }
        HideSpecificUIElement();
    }

    void HideSpecificUIElement()
    {
        // Hide the specific UI element
        uiElementTohide.SetActive(false);
    }
}