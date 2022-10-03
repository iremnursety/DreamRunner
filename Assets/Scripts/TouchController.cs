using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    //TODO: Swipe Directions!
    public MoveDirection swipeDirection;
    [SerializeField] private Vector2 firstPointPos;
    [SerializeField] private Vector2 lastPointPos;
    [SerializeField] private Vector2 direction;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        swipeDirection = MoveDirection.None;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        firstPointPos = eventData.pressPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lastPointPos = eventData.position;
        CalculatePos();
    }

    private void CalculatePos()
    {
        direction = lastPointPos - firstPointPos;

        var directionX = Mathf.Abs(direction.x);
        var directionY = Mathf.Abs(direction.y);
        const float tolerance = 0.001f;

        if (directionX > directionY)
        {
            swipeDirection = direction.x < 0 ? MoveDirection.Left : MoveDirection.Right;
            playerController.PlayerDirection(swipeDirection);
        }

        if (Math.Abs(directionX - directionY) < tolerance && directionX > 0f)
        {
            swipeDirection = direction.x < 0 ? MoveDirection.Left : MoveDirection.Right;
            playerController.PlayerDirection(swipeDirection);
        }

        if (directionX < directionY)
        {
            swipeDirection = direction.y > 0 ? MoveDirection.Up : MoveDirection.Down;
            playerController.PlayerDirection(swipeDirection);
        }

        swipeDirection = MoveDirection.None;
    }
}