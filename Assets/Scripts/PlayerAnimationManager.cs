using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public static PlayerAnimationManager Instance { get; private set; }
    public Animator animator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //TODO: Work on animations switch. especially leftSide switch.
    public void TapToStart()
    {
        animator.SetTrigger("TapToStart");
    }

    //TODO: Add blocker type as Water
    /*public void BlockWater()
    {
        animator.SetTrigger("BlockWater");
        //ItemsManager.Instance.ResetPosition();
    }*/


    public void BlockBarrier()
    {
        animator.SetTrigger("BlockBarrier");
    }

    public void PlayerDied()
    {
        animator.SetTrigger("PlayerDied");
    }

    public void Jumping()
    {
        animator.SetTrigger("Jumping");
    }

    public void Rolling()
    {
        animator.SetTrigger("Rolling");
    }

    public void RightSide()
    {
        animator.SetTrigger("RightSide");
    }

    public void LeftSide()
    {
        animator.SetTrigger("LeftSide");
    }

    public void Running()
    {
        animator.SetTrigger("Running");
    }
}