using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 characterPos;
    [SerializeField] private float playerPos;
    [SerializeField] private int hitCount;
    [SerializeField] private bool isDead;
    [SerializeField] private TextMeshProUGUI hitCountText;
    [SerializeField] private Rigidbody rdbody;
    [SerializeField] private bool isStarted;
    public float speed;

    private void Start()
    {
        characterPos = transform.position;
        rdbody = gameObject.GetComponent<Rigidbody>();
        speed = 5f;
        isDead = false;
        hitCount = 0;
        hitCountText.enabled = true;
        hitCountText.text = "Hit Count: "+hitCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            hitCount += 1;
            hitCountText.text = "Hit Count: " + hitCount;
            //PlayerAnimationManager.Instance.BlockBarrier();
            Invoke(nameof(SetHitZero), 5f);
            if (hitCount <= 1) return;
            else
            {
                isDead = true;
                speed = 0f;
                hitCount = 0;
                //TODO: Falling animation.
                PlayerAnimationManager.Instance.PlayerDied();
                CanvasManager.Instace.GameOverImportant();
                Invoke("GameOverCalled", 6f);
            }
        }
    }

    private void SetHitZero()
    {
        hitCount = 0;
        hitCountText.text = "Hit Count: " + hitCount;
        //PlayerAnimationManager.Instance.Running();
    }

    private void Update()
    {
        ChangeSpeed();
    }

    //TODO: Get swipe info and road Vector for swipe left and right.(DONE)
    //TODO: Set swipe Animations.
    private void SwipeLeft()
    {
        PlayerPosition();
        switch (playerPos)
        {
            case -3:
                break;
            case 0:
                transform.position = new Vector3(-3, characterPos.y, characterPos.z);
                break;
            case 3:
                transform.position = new Vector3(0, characterPos.y, characterPos.z);
                break;
            default:
                return;
        }
    }

    private void FixedUpdate()
    {
        Running();
    }

    private void Running()
    {
        Vector3 move = transform.forward * speed * Time.fixedDeltaTime;
        //Vector3 move = transform.forward * speed * Time.deltaTime;
        rdbody.MovePosition(rdbody.position + move);
    }

    private void SwipeRight()
    {
        characterPos = transform.position;
        PlayerPosition();
        switch (playerPos)
        {
            case -3:
                transform.position = new Vector3(0, characterPos.y, characterPos.z);
                break;
            case 0:
                transform.position = new Vector3(3, characterPos.y, characterPos.z);
                break;
            case 3:
                break;
            default:
                return;
        }
    }

    public void PlayerDirection(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                PlayerAnimationManager.Instance.Jumping();
                Debug.Log("Jumping");
                break;
            case MoveDirection.Down:
                PlayerAnimationManager.Instance.Rolling();
                Debug.Log("Rolling");
                break;
            case MoveDirection.Left:
                SwipeLeft();
                PlayerAnimationManager.Instance.LeftSide();
                Debug.Log("SwipeLeft");
                break;
            case MoveDirection.Right:
                Debug.Log("SwipeRight");
                PlayerAnimationManager.Instance.RightSide();
                SwipeRight();
                break;
            default:
                Debug.Log("Default");
                return;
        }
    }

    private void PlayerPosition()
    {
        characterPos = transform.position;
        playerPos = characterPos.x;
    }

    private void ChangeSpeed()
    {
        IsGameStart();

        if (!isStarted)
            speed = 0;
        else
        {
            if (isDead)
            {
                if (speed <= 50)
                    speed += 0.2f * Time.deltaTime;
            }
            else
                return;
        }
    }

    private void GameOverCalled()
    {
        GameManager.Instace.GameOver();
        isDead = false;
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void IsGameStart()
    {
        isStarted = GameManager.Instace.isStart;
    }
}