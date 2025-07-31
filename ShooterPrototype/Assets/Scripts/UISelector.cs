using UnityEngine;
using UnityEngine.EventSystems;

public class UISelector : MonoBehaviour
{
    [SerializeField] private GameObject selectedButton;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(selectedButton);
    }
}
