using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public bool playerIsNear = false;
    private float checkRadius = 0.1f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform railCheckLeft;
    [SerializeField]
    private Transform railCheckRight;
    [SerializeField]
    private Transform railCheckUp;
    [SerializeField]
    private Transform railCheckDown;

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Physics2D.OverlapCircle(railCheckLeft.position, checkRadius, layerMask))
                {
                    MoveLeft();
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Physics2D.OverlapCircle(railCheckRight.position, checkRadius, layerMask))
                {
                    MoveRight();
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Physics2D.OverlapCircle(railCheckUp.position, checkRadius, layerMask))
                {
                    MoveUp();
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (Physics2D.OverlapCircle(railCheckDown.position, checkRadius, layerMask))
                {
                    MoveDown();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIsNear = false;
    }

    private void MoveLeft()
    {
        Debug.Log("MovedLeft");
        transform.parent.position -= new Vector3(1, 0, 0);
    }

    private void MoveRight()
    {
        Debug.Log("MovedRight");
        transform.parent.position += new Vector3(1, 0, 0);
    }

    private void MoveUp()
    {
        Debug.Log("MovedUp");
        transform.parent.position += new Vector3(0, 1, 0);
    }

    private void MoveDown()
    {
        Debug.Log("MovedDown");
        transform.parent.position -= new Vector3(0, 1, 0);
    }
}
