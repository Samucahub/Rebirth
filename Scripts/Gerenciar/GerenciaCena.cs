using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciaCena : MonoBehaviour
{
    public static Vector3 spawnPosition;

    public static void LoadScene(string NomeCena, Vector3 position)
    {
        spawnPosition = position;
        SceneManager.LoadScene(NomeCena);
    }
}
