using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Candy : MonoBehaviour
{
    #region Exposed

    
    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        IsLost = false;
        IsWon = false;
    }

    #endregion

    #region Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            IsStarTaken = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            IsLost = true;
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

    public bool IsLost { get => _isLost; set => _isLost = value; }
    public bool IsWon { get => _isWon; set => _isWon = value; }
    public bool IsStarTaken { get => _isStarTaken; set => _isStarTaken = value; }

    #endregion
}
