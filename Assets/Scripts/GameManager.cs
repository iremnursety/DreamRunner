using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instace { get; private set; }
   public bool isStart;
   public PlayerController playerController;

   private void Awake()
   {
      if (Instace == null)
         Instace = this;
      else
         Destroy(gameObject);
   }

   public bool GameStarted
   {
      get { return isStart; }
      set { isStart = value; }
   }

   public void GameStart()
   {
      isStart = true;
      PlayerAnimationManager.Instance.TapToStart();
      Debug.Log("Before speed");
      playerController.Speed = 5f;
      Debug.Log("Speed sended");
      CanvasManager.Instace.GameStart();

   }

   private void BackToStartPos()
   {
      RoadManager.Instance.ResetSpawned();
      playerController.transform.position=new Vector3(0,0,-10f);
   }

   public void GameOver()
   {
      CanvasManager.Instace.GameOver();
      ScoreManager.Instance.SetScoreZero();
      BackToStartPos();
      isStart = false;
   }
}
