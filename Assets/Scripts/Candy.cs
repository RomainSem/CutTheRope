using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Candy : MonoBehaviour
{
    #region Exposed

    [SerializeField] bool _isBubbleTaken;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        IsLost = false;
        IsWon = false;
        IsStarTaken = false;
        //IsBubbleTaken = false;

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
            //Vector2 bubblePos = _bubble.transform.position;
            //Vector2 worldPosition = Camera.main.ScreenToWorldPoint(bubblePos);
            //transform.position = bubblePos;
            //transform.parent = _bubble.transform;
            GetComponent<CircleCollider2D>().isTrigger = true;
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
            IsBubbleTaken = true;
            _rgbdy.gravityScale = 0;
            _rgbdy.velocity = Vector2.zero;
            transform.position = _bubbleRgbdy.worldCenterOfMass;
            _bubbleRgbdy.velocity = new Vector2(0, 2);
            //_bubble.GetComponent<FixedJoint2D>().enabled = true;
            GetComponent<FixedJoint2D>().enabled = true;
            //Debug.Log(IsBubbleTaken);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            IsWon = true;
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
