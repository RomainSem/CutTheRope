using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    #region Exposed

    [SerializeField] float _bubbleSpeed = 1f;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
    }

    private void Awake()
    {
        _candy = GameObject.FindGameObjectWithTag("Candy");
        _candyRefScript = _candy.GetComponent<Candy>();
        //_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log("UPDATE BUBBLE : " + _candyRefScript.IsBubbleTaken);
        //if (_candyRefScript.IsBubbleTaken/*gameObject.transform.childCount == 2*/)
        //{
        //    Vector2 direction = new Vector3(transform.position.x, transform.position.y + 1);
        //    float distanceThisFrame = _bubbleSpeed * Time.deltaTime;
        //    //transform.position = Vector2.MoveTowards(transform.position, direction, distanceThisFrame);
        //}
        //RaycastOnBubble();
    }

    #endregion

    #region Methods

    private void OnMouseDown()
    {
        if (_candyRefScript.IsBubbleTaken)
        {
            //_candy.transform.parent = null;
            Destroy(gameObject);
            _candy.GetComponent<Rigidbody2D>().gravityScale = 1;
            _candyRefScript.IsBubbleTaken = false;
        }
    }

    //private void RaycastOnBubble()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    int layerMask = /*1 << */LayerMask.NameToLayer("Bubble");
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
    //    {
    //        Debug.Log("Le Raycast a touché un objet du layer MyLayer");
    //    }
    //}

    #endregion

    #region Private & Protected

    GameObject _candy;
    Candy _candyRefScript;
    //bool _isMouseDown;
    //Rigidbody2D _rigidbody;

    #endregion
}
