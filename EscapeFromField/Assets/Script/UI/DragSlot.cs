using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    public static DragSlot instance;

    public Slot dragSlot;

    [SerializeField] 
    private Image imageItem;

    void Start()
    {
        instance = this;
    }

    public void DragSetImage(Image _imageItem)
    {
        imageItem.sprite = _imageItem.sprite;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}