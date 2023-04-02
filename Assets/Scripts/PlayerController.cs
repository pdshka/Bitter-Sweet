using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    public bool yEnabled = true;
    private Stats stats;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;
    private int platformsCount = 0;
    private bool usedTeleporter = false;
    private string teleportToId = "";

    void Start()
    {
        stats = GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void LoadData(GameData gameData)
    {
        if (SceneManager.GetActiveScene().name != "RiverRace")
            this.transform.position = gameData.playerPosition;
    }

    public void SaveData(ref GameData gameData)
    {
        if (usedTeleporter)
        {
            gameData.playerPosition = gameData.teleporters[teleportToId];
        }
        else
        {
            gameData.playerPosition = this.transform.position;
        }
    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        if (yEnabled)
            direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y) * stats.speed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + direction * stats.speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Debug.Log("EnterPlatform");
            platformsCount++;
            this.transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            platformsCount--;
            Debug.Log("ExitPlatform");
            if (platformsCount == 0)
                this.transform.parent = null;
        }
    }

    public void UseTeleport(string tpTo)
    {
        usedTeleporter = true;
        teleportToId = tpTo;
    }
}
