using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corde : MonoBehaviour
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
        if (Input.GetMouseButton(0))
        {
            isMouseDown = true;
        }
        else
        {
            isMouseDown= false;
        }
    }


    #endregion

    #region Methods


    void OnMouseOver()
    {
        if (isMouseDown)
        {
            // Affiche un effet de coupe


            // Détruire le GameObject sur lequel la souris passe
            Destroy(gameObject);
        }
    }



    #endregion

    #region Private & Protected

    bool isMouseDown;


    #endregion
}
