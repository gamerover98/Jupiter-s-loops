using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Ship ship;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}