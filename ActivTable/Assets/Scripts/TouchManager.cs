using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    private Vector3 playerSize;
    Rigidbody2D rigidbody2d;

    // Use this for initialization
    void Start () {
        playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        if(Input.touchCount > 0)
        {
            var touchPositions = Input.touches.Select(t => Camera.main.ScreenToWorldPoint(t.position)).ToList();

            var touchedInside = touchPositions.Where(t => (t.x >= transform.position.x && t.x < transform.position.x + playerSize.x ||
            t.x <= transform.position.x && t.x > transform.position.x - playerSize.x) &&
            (t.y >= transform.position.y && t.y < transform.position.y + playerSize.y ||
            t.y <= transform.position.y && t.y > transform.position.y - playerSize.y));

            if (touchedInside.Any())
            {
                var touchPos = touchedInside.ToList().First();            

                rigidbody2d.MovePosition(touchPos);
            }
        }
	}
}
