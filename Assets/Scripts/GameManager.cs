using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Ship ship;
    public Camera camera;

    //public Portal portal;
    //public CapsuleController capsuleController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


}