using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corde : MonoBehaviour
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
            // Affiche un effet de coupe
            Vector2 mousePos = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            if (!_isTrailGenerated)
            {
                _isTrailGenerated= true;
                trail = Instantiate(_trailPrefab, worldPosition, Quaternion.identity);
            }
            trail.transform.position = worldPosition;
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
            Destroy(gameObject);
        }
    }

    private void OnMouseUp()
    {
        _isTrailGenerated = false;
        Destroy(trail);
    }



    #endregion

    #region Private & Protected

    bool _isMouseDown;
    bool _isTrailGenerated;
    GameObject trail;


    #endregion
}
