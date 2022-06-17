using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Vector3 mousePosition;
    public Vector2 offset;
    public float velocity = 5f;
    public float diagVel = 3.53f;
    public GameObject upSwing, leftSwing, downSwing, rightSwing;
    
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = new Vector2(mousePosition.x - playerRB.position.x, mousePosition.y - playerRB.position.y);

        //swing
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Debug.Log("reached");
            if (offset.x > 0 && offset.x >= Mathf.Abs(offset.y))
            {
                //Debug.Log("right");
                StartCoroutine(waiter(rightSwing));
            }
            else if (offset.y > 0 && offset.y > Mathf.Abs(offset.x))
            {
                //Debug.Log("up");
                StartCoroutine(waiter(upSwing));
            }
            else if (offset.x < 0 && Mathf.Abs(offset.x) >= Mathf.Abs(offset.y))
            {
                //Debug.Log("left");
                StartCoroutine(waiter(leftSwing));
            }
            else if (offset.y < 0 && Mathf.Abs(offset.y) > Mathf.Abs(offset.x))
            {
                //Debug.Log("down");
                StartCoroutine(waiter(downSwing));
            }
        }

        //movement
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x - diagVel * Time.fixedDeltaTime, playerRB.position.y + diagVel * Time.fixedDeltaTime));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x - diagVel * Time.fixedDeltaTime, playerRB.position.y - diagVel * Time.fixedDeltaTime));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x + diagVel * Time.fixedDeltaTime, playerRB.position.y - diagVel * Time.fixedDeltaTime));
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x + diagVel * Time.fixedDeltaTime, playerRB.position.y + diagVel * Time.fixedDeltaTime));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {

        }
        else if (Input.GetKey(KeyCode.W))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x, playerRB.position.y + velocity * Time.fixedDeltaTime));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x - velocity * Time.fixedDeltaTime, playerRB.position.y));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x, playerRB.position.y - velocity * Time.fixedDeltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRB.MovePosition(new Vector2(playerRB.position.x + velocity * Time.fixedDeltaTime, playerRB.position.y));
        }
    }

    IEnumerator waiter(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}    