using UnityEngine;

public class EscuchaEvento : MonoBehaviour
{
    [SerializeField] private ViendoEventos viendoEventos;

    private void OnEnable()
    {
        if(viendoEventos != null) 
            viendoEventos.OnLetterPressed += EjecucionDeEvento;
    }

    private void OnDisable()
    {
        if (viendoEventos != null)
            viendoEventos.OnLetterPressed -= EjecucionDeEvento;
    }

    private void EjecucionDeEvento()
    {
        Debug.Log("El evento se ejecuto");
    }
}
