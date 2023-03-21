using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutRope : MonoBehaviour
{
    #region Exposed

    [SerializeField] GameObject _trailPrefab;

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
            _isMouseDown = true;
        }
        else
        {
            _isMouseDown = false;
        }
    }


    #endregion

    #region Methods


    void OnMouseOver()
    {
        if (_isMouseDown)
        {
            // Détruire le GameObject sur lequel la souris passe
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }

    #endregion

    #region Private & Protected

    bool _isMouseDown;


    #endregion
}
