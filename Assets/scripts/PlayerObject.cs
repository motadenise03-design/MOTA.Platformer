using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
   
    public TMP_Text healthText;
    
    public float speed = 10;
    
    public float jumpForce = 200;

    public int coinCollected = 0;

    public TMP_Text coinText;

    public int health = 50;

    private SpriteRenderer _spr_rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * speed);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
        if (other.GetComponent<Collectable>())
        {
            coinCollected++;
            
        }

        else if (other.GetComponent<EnemyObj>())
        {
            health = health - 10;
        }
        else if (other.GetComponent<GOAL>())
        {
            SceneManager.LoadScene(other.GetComponent<GOAL>().NextLevel);
        }
        
        coinText.text = "Coins Collected: " + coinCollected.ToString();
        healthText.text = "Total Health:" + health.ToString();
    }

}