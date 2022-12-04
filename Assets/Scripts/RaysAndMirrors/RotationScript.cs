using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool rotationOn = true;
    private bool playerIsNear = false;
    [SerializeField]
    private GameObject block;
    //[SerializeField]
    //private Sprite[] sprites = new Sprite[4];
    private SpriteRenderer spriteRenderer;
    //private int rotation = 0;
    private Animator animator;
    private bool isRotating = false;
    private int defaultOrderInLayer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        defaultOrderInLayer = spriteRenderer.sortingOrder;
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.R) && rotationOn && !isRotating)
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
        switch(animator.GetInteger("rotation"))
        {
            case 0:
                spriteRenderer.sortingOrder = defaultOrderInLayer;
                break;
            case 1:
                spriteRenderer.sortingOrder = defaultOrderInLayer;
                break;
            case 2:
                spriteRenderer.sortingOrder = defaultOrderInLayer + 2;
                break;
            case 3:
                spriteRenderer.sortingOrder = defaultOrderInLayer + 2;
                break;
            default:
                break;
        }
        //spriteRenderer.sprite = sprites[rotation];
        isRotating = false;
    }
}
