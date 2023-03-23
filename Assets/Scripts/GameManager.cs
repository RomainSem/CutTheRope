using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Exposed

    [SerializeField] GameObject _winPanel;
    [SerializeField] GameObject _losePanel;
    [SerializeField] Image[] _nbStars;
    [SerializeField] Sprite _goldenStarSprite;
    [SerializeField] Sprite _emptyStarSprite;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        _candyRef = GameObject.FindGameObjectWithTag("Candy").GetComponent<Candy>();
    }

    void Update()
    {
        Win();
        Lose();
        StarTaken();
    }

    #endregion

    #region Methods

    public void ReloadCurrentScene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void Win()
    {
        if (_candyRef.IsWon)
        {
            _winPanel.SetActive(true);
        }
    }

    private void Lose()
    {
        if (_candyRef.IsLost)
        {
            _losePanel.SetActive(true);
        }
    }

    private void StarTaken()
    {
        if (_candyRef.IsStarTaken)
        {
            foreach (Image star in _nbStars)
            {
                if (star.sprite == _emptyStarSprite)
                {
                    star.sprite = _goldenStarSprite;
                    _candyRef.IsStarTaken = false;
                    return;
                }
            }
        }
    }

    #endregion

    #region Private & Protected

    Candy _candyRef;

    #endregion
}
