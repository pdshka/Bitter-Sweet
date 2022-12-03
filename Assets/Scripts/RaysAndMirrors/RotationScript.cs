using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool playerIsNear = false;
    [SerializeField]
    private GameObject block;
    //[SerializeField]
    //private Sprite[] sprites = new Sprite[4];
    private SpriteRenderer spriteRenderer;
    //private int rotation = 0;
    private Animator animator;
    private bool isRotating = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.R) && !isRotating)
            {
                isRotating = true;
                Debug.Log((animator.GetInteger("rotation") + 1) % 4);
                animator.SetInteger("rotation", (animator.GetInteger("rotation") + 1) % 4);
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

    private void RotateBlock()
    {
        block.transform.Rotate(0, 0, -90);
        //rotation = (rotation + 1) % 4;
        if (animator.GetInteger("rotation") == 2)
        {
            spriteRenderer.sortingOrder += 2;
        }
        else if (animator.GetInteger("rotation") == 0)
        {
            spriteRenderer.sortingOrder -= 2;
        }
        //spriteRenderer.sprite = sprites[rotation];
        isRotating = false;
    }
}
