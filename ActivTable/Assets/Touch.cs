using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour {
    Text myTextField;
    public Transform player1Paddle, player2Paddle;
    Ray mouseRay;
    RaycastHit hitInfo;
	// Use this for initialization
	void Start () {
        Input.multiTouchEnabled = true;

        //myTextField = GetComponent<Text>();

        //myTextField.text = "Touch Count: " + Input.touchCount;

    }
    private void FixedUpdate()
    {
        mouseRay =  Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out hitInfo))
        {
            player1Paddle.position = new Vector3(hitInfo.point.x, player1Paddle.position.y, hitInfo.point.z);
        }

    }


    // Update is called once per frame
    void Update () {

        //myTextField.text = "Touch Count: " + Input.touchCount;

        if(Input.touchCount > 0)
        {
            var touch1 = Input.touches[1];
                player1Paddle.position = new Vector3(touch1.position.x, player1Paddle.position.y, touch1.position.y);

            if(Input.touchCount > 1)
            {
                var touch2 = Input.touches[2];
                player2Paddle.position = new Vector3(touch2.position.x, player2Paddle.position.y, touch2.position.y);
            }


        }



    }
}
