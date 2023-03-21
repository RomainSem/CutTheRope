using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
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
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPosition;
        Debug.Log(mousePos);
    }

    
    #endregion

    #region Methods


    #endregion

    #region Private & Protected

    #endregion
}
