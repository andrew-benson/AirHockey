using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool wasJustClicked = true;
    bool canMove;
    Vector2 playerSize;

    // Use this for initialization
    void Start()
    {
        playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        // Touch input
        if(Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
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
                    transform.position = touchPos;
                }
            }
        }
        else
        {
            canMove = false;
        }


        // Mouse Input
        if (Input.GetMouseButton(0))
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
                transform.position = mousePos;
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }
}