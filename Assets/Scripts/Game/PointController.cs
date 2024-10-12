using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PointController : MonoBehaviour
{
    TMP_Text Text;
    float puntos;
    private void Awake()
    {
        Text = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        Imprimir(0);
    }
    private void Imprimir(float point)
    {
        puntos += point;
        Text.text = "Puntos: " + puntos;
    }
    private void OnEnable()
    {
        PlayerMovement.EventPoint += Imprimir;
    }
    private void OnDisable()
    {
        PlayerMovement.EventPoint += Imprimir;

    }
}
