using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    public float moveForce = 10f;
    public float jumpForce = 20f;
    private Rigidbody2D player;
    private bool isGrounded = true;
    GroundSpawn groundSpawn;
    private GameObject temp;
    ScoreManager score;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        groundSpawn = GameObject.Find("GroundSpawnManager").GetComponent<GroundSpawn>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }   
    void Update()
    {
        PlayerMove();
        if (Input.GetButtonDown("Jump") && isGrounded==true)
        {
            PlayerJump();
        }
        score.ScoreUpdate((int)player.transform.position.x);
    }
    public void PlayerMove()
    {
        transform.Translate(Vector3.right * moveForce * Time.deltaTime);
    }
    private void PlayerJump()
    {
       
            player.gravityScale = 1.5f;
            player.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
      
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            GroundSpawn.Instance.BackToGroundPool(collision.gameObject);
            temp = collision.gameObject;            
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        GroundSpawn.Instance.SpawnGround();
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
            
    }

    IEnumerator GroundPool()
    {
        yield return new WaitForSeconds(1f);
        GroundSpawn.Instance.BackToGroundPool(temp);
    }
}
