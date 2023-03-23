using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    #region Exposed


    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _candy = GameObject.FindGameObjectWithTag("Candy");
        _candyCollider = _candy.GetComponent<CircleCollider2D>();
        _candyRefScript = _candy.GetComponent<Candy>();
    }

    #endregion

    #region Methods

    private void OnMouseDown()
    {
        if (_candyRefScript.IsBubbleTaken)
        {
            _candyRefScript.IsBubbleTaken = false;
            _candyCollider.enabled = true;
            _candyCollider.isTrigger = false;
            _candy.GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            _candyRefScript.IsStarTaken = true;
            Destroy(collision.gameObject);
        }
    }


    #endregion

    #region Private & Protected

    GameObject _candy;
    CircleCollider2D _candyCollider;
    Candy _candyRefScript;

    #endregion
}
