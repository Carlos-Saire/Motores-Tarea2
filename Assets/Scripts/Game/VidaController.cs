using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VidaController : MonoBehaviour
{
    TMP_Text Text;
    private void Awake()
    {
        Text = GetComponent<TMP_Text>();
    }
    private void Imprimir(float life)
    {
        Text.text = "Vida: " + life;
    }
    private void OnEnable()
    {
        PlayerMovement.EventLife += Imprimir;
    }
    private void OnDisable()
    {
        PlayerMovement.EventLife += Imprimir;

    }
}
