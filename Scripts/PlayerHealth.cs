using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    public int totalHealth = 7;
    public RectTransform heartUI;
    public RectTransform gameoverMenu;
    public GameObject hordes;
    private int health;
    private float heartSize = 16f;
    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerControler _controller;
    public Transform spanwpoint;
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerControler>();
        spanwpoint = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    public void AddDamage(int amount)
    {
        health = health - amount;
        StartCoroutine("VisualFeedback");

        if(health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }
        heartUI.sizeDelta = new Vector2(heartSize * health,heartSize);
        Debug.Log("Player Got damaged. His Current health is "+ health);
    }
    public void AddHealth(int amount)
    {
        health += amount;
        if(health >= totalHealth)
        {
            health = totalHealth;
        }
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        Debug.Log("Player got some life. His current health is + " + health); 
    }
    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.color = Color.white;
    }
    private void OnEnable()
    {
        _animator.enabled = true;
        _controller.enabled = true;
    }
    private void OnDisable()
    {
        gameoverMenu.gameObject.SetActive(true);
        hordes.SetActive(false);
        _animator.enabled = false;
        _controller.enabled = false;
        _renderer.color = Color.white;
        health = totalHealth;
        heartUI.sizeDelta = new Vector2(heartSize *health,heartSize);

        _controller.transform.position = new Vector2(spanwpoint.position.x, spanwpoint.position.y);
    }
}
