using System;
using UnityEngine;

public class ViendoEventos : MonoBehaviour
{
    public event Action OnLetterPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnLetterPressed?.Invoke();
        }
    }
}
