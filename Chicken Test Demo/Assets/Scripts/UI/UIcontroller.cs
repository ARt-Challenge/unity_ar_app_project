using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button hideButton;
    public GameObject[] uiElements;
    public GameObject uiElementToUnhide;

    void Start()
    {
        hideButton.onClick.AddListener(HideAllUIElements);
    }

    void HideAllUIElements()
    {
        foreach (GameObject uiElement in uiElements)
        {
            // Hides all UI element exept specific
            if (uiElement != uiElementToUnhide)
            {
                uiElement.SetActive(false);
            }
        }
        UnhideSpecificUIElement();
    }

    void UnhideSpecificUIElement()
    {
        // Unhide the specific UI element
        uiElementToUnhide.SetActive(true);
    }
}
