using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float speed = 1f;
    public Vector2 direction;
    public Color initialColor = Color.white;
    public Color finalColor;
    public float livingTime = 3f;
    private SpriteRenderer _renderer;
    private float _startinTime;
    private Rigidbody2D _rigidbody;
    private bool _returning;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody= GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {   
        _startinTime = Time.time;
        //Destroy the bullet after some time
        Destroy(this.gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        float _timeSinceStarted = Time.time - _startinTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);   

    }
    private void FixedUpdate()
    {
        Vector2 movement = direction.normalized * speed;
        _rigidbody.velocity = movement;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("AddDamage", damage);
            Destroy(this.gameObject);
        }
        if(_returning == true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("AddDamage");
            Destroy(gameObject);
        }
    }
    public void AddDamage()
    {
        _returning = true;
        direction *= -1f;
    }
}
