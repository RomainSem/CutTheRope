using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailGenerator : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            // Affiche un effet de coupe
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               _trail = Instantiate(_trailPrefab, worldPosition, Quaternion.identity);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(_trail);
        }
    }


    #endregion

    #region Methods


    #endregion

    #region Private & Protected

    GameObject _trail;

    #endregion
}
