using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UISelector : MonoBehaviour
{
    [SerializeField] private GameObject selectedButton;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(selectedButton);
    }
}
