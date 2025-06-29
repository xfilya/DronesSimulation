using DG.Tweening;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsFree { get; set; } 

    public void Initialize()
    {
        transform.localScale = Vector3.zero;

        transform.DOScale(1, 0.4f).SetEase(Ease.OutCubic);

        IsFree = true;
    }

    public void Harvest()
    {
        transform.DOScale(0, 0.2f).SetEase(Ease.InBack);        
    }
}
