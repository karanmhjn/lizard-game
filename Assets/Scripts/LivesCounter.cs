using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] private float lifeImageWidth = 26f;
    [SerializeField] private IntSO livesSO;

    private RectTransform _rect;

    PlayerLife playerLife;
    [SerializeField] private GameObject Dave;

    private void setLife(int value)
    {
        if(value < 0)
        {
            playerLife.GameOver();
        }

        AdjustImageWidth();
    }

    private void Awake()
    {
        playerLife = Dave.GetComponent<PlayerLife>();
        _rect = transform as RectTransform;

        AdjustImageWidth();
    }

    private void AdjustImageWidth()
    {
        _rect.sizeDelta = new Vector2(lifeImageWidth*livesSO.Value, _rect.sizeDelta.y);
    }

    public void AddLife(int num = 1)
    {
        livesSO.Value += num;
        setLife(livesSO.Value);
    }

    public void RemoveLife(int num = 1)
    {
        livesSO.Value -= num;
        setLife(livesSO.Value);
    }
}
