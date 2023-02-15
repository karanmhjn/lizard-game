using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] private float lifeImageWidth = 26f;
    [SerializeField] private int maxNumberOfLives = 3;
    [SerializeField] private int currentNumberOfLives =3;

    private RectTransform _rect;

    PlayerLife playerLife;
    [SerializeField] private GameObject Dave;

    // public UnityEvent OutOfLives;

    public int NumOfLives
    {
        get => currentNumberOfLives;
        private set
        {
            if(value < 0)
            {
                playerLife.KillDave();
            }



            currentNumberOfLives = Mathf.Clamp(value, 0, maxNumberOfLives);
            AdjustImageWidth();
        }
    }

    private void Awake()
    {
        playerLife = Dave.GetComponent<PlayerLife>();
        _rect = transform as RectTransform;
        AdjustImageWidth();
    }

    private void AdjustImageWidth()
    {
        _rect.sizeDelta = new Vector2(lifeImageWidth*currentNumberOfLives, _rect.sizeDelta.y);
    }

    public void AddLife(int num = 1)
    {
        NumOfLives += num;
    }

    public void RemoveLife(int num = 1)
    {
        NumOfLives -= num;
    }
}
