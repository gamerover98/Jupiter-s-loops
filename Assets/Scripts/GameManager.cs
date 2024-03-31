using Environment.Entity;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MonoShip ship;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}