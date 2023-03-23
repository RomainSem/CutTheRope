using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Candy : MonoBehaviour
{
    #region Exposed

    [SerializeField] bool _isBubbleTaken;
    [SerializeField] GameObject[] _ropesToDestroy;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        _bubble = GameObject.FindGameObjectWithTag("Bubble");
        _bubbleRgbdy = _bubble.GetComponent<Rigidbody2D>();
        _rgbdy = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        Debug.Log(Physics.gravity);
        Debug.Log("UPDATE Candy : " + IsBubbleTaken);
        if (IsBubbleTaken)
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
            foreach (GameObject rope in _ropesToDestroy)
            {
                Destroy(rope);
            }
        }
        LimitY();
    }

    #endregion

    #region Methods

    private void LimitY()
    {
        if (gameObject.transform.position.y <= -10 || gameObject.transform.position.y >= 10)
        {
            Destroy(gameObject);
            IsLost = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            IsStarTaken = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bubble")
        {
            _rgbdy.velocity = Vector2.zero;
            _rgbdy.gravityScale = 0;
            IsBubbleTaken = true;
            transform.position = _bubbleRgbdy.worldCenterOfMass;
            _bubbleRgbdy.velocity = new Vector2(0, 3);
            _collider.enabled = false;
            GetComponent<FixedJoint2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            IsWon = true;
            Destroy(gameObject);
        }
    }

    #endregion

    #region Private & Protected

    bool _isLost;
    bool _isWon;
    bool _isStarTaken;
    //bool _isBubbleTaken;
    GameObject _bubble;
    Rigidbody2D _bubbleRgbdy;
    Rigidbody2D _rgbdy;
    CircleCollider2D _collider;

    public bool IsLost { get => _isLost; set => _isLost = value; }
    public bool IsWon { get => _isWon; set => _isWon = value; }
    public bool IsStarTaken { get => _isStarTaken; set => _isStarTaken = value; }
    public bool IsBubbleTaken { get => _isBubbleTaken; set => _isBubbleTaken = value; }

    #endregion
}
