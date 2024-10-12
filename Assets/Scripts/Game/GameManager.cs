using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float Puntos;
    [SerializeField] private PositionTable PositionTable;
    private void PointAlmacenar(float point)
    {
        Puntos += point;
    }
    private void GameOver(float life)
    {
        if (life <= 0)
        {
            PositionTable.AddNewScore(Puntos);
            SceneManager.LoadScene("GameOver");
        }   
    }
    private void OnEnable()
    {
        PlayerMovement.EventPoint += PointAlmacenar;
        PlayerMovement.EventLife += GameOver;
    }
    private void OnDisable()
    {
        PlayerMovement.EventPoint += PointAlmacenar;
        PlayerMovement.EventLife -= GameOver;
    }
}
