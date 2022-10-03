using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas touchControllerCanvas;
    [SerializeField] private Canvas tapToStartCanvas;
    [SerializeField] private Canvas resetGameCanvas;
    public static CanvasManager Instace { get; private set; }

    private void Awake()
    {
        if (Instace == null)
            Instace = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        resetGameCanvas.enabled = false;
        touchControllerCanvas.enabled = false;
        GameManager.Instace.isStart = false;

        tapToStartCanvas.enabled = true;
    }

    public void GameStart()
    {
        tapToStartCanvas.enabled = false;
        touchControllerCanvas.enabled = true;
    }

    public void GameOver()
    {
        ResetGame();
    }

    //Calling this first. After this GameOver is calling state.
    public void GameOverImportant()
    {
        touchControllerCanvas.enabled = false;
        GameManager.Instace.isStart = false;
    }

    private void ResetGame()
    {
        //TODO: Reset Game Canvas Panel Animation.
        //resetGameCanvas.enabled = true;
        RoadManager.Instance.ResetSpawned();
        Invoke(nameof(ResetOver),4f);
    }

    private void ResetOver()
    {
        //resetGameCanvas.enabled = false;
        tapToStartCanvas.enabled = true;
    }
    
}