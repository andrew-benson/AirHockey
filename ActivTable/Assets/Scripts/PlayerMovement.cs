using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2
    }

    public PlayerNumber playerNumber; 
    Rigidbody2D rigidbod2d;
    bool wasJustClicked = true;
    bool canMove;
    Vector2 playerSize;
    int playerTouchIndex;

    // Use this for initialization
    void Start()
    {
        playerTouchIndex = playerNumber == PlayerNumber.Player1 ? 0 : 1; 
        rigidbod2d = GetComponent<Rigidbody2D>();
        playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {

#if !UNITY_EDITOR
        // Touch input
        if(Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(playerTouchIndex);
            var touchPos = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                if ((touchPos.x >= transform.position.x && touchPos.x < transform.position.x + playerSize.x ||
                touchPos.x <= transform.position.x && touchPos.x > transform.position.x - playerSize.x) &&
                (touchPos.y >= transform.position.y && touchPos.y < transform.position.y + playerSize.y ||
                touchPos.y <= transform.position.y && touchPos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if (canMove)
                {
                    rigidbod2d.MovePosition(touchPos);
                }
            }
        }
        else
        {
            canMove = false;
        }
#else
        // Mouse Input
        if (Input.GetMouseButton(playerTouchIndex))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if ((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x ||
                mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) &&
                (mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y ||
                mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                rigidbod2d.MovePosition(mousePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }
#endif
    }
}