using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private float MinY;
    [SerializeField] private float MaxY;
    int index;
    private void Start()
    {
        Invoke("GenerarPuntos", 0);
    }
    private void GenerarPuntos()
    {
        index=Random.Range(0, prefab.Length);
        transform.position = new Vector2(transform.position.x, Random.Range(MinY, MaxY));
        Instantiate(prefab[index],transform.position,transform.rotation);
        Invoke("GenerarPuntos", 0.2f);
    }
}
