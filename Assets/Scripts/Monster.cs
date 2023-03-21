using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    #region Exposed


    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        
    }

    void Start()
    {

    }

    void Update()
    {
        
    }


    #endregion

    #region Methods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            // Win
        }
    }

    #endregion

    #region Private & Protected

    #endregion
}
