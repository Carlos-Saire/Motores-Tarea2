using System.Collections;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private GameObject indicador;
    [SerializeField] private float MinY;
    [SerializeField] private float MaxY;
    [SerializeField] private float TimeEnemy;
    int index;
    Vector2 NewTransform;
    private void Start()
    {
        Invoke("GenerarSeñal", 0);
    }
    private void GenerarSeñal()
    {
        NewTransform = new Vector2(7.9f, Random.Range(MinY, MaxY));
        transform.position = new Vector2(transform.position.x, NewTransform.y);
        GameObject go= Instantiate(indicador, NewTransform,transform.rotation);
        StartCoroutine(TiempoDeEspera(go));
    }
    private void GenerarEnemy(GameObject go)
    {
        index=Random.Range(0,prefab.Length-1);
        Instantiate(prefab[index],transform.position,transform.rotation);
        Destroy(go);
        Invoke("GenerarSeñal", 0);
    }
    private IEnumerator TiempoDeEspera(GameObject go)
    {
        yield return new WaitForSeconds(TimeEnemy);
        GenerarEnemy(go);
    }
}
