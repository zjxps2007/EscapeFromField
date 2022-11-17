using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; //아이템의 이름 - 키값
    public string[] part; //부위
    public int[] num; // 수치

}
public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
    [SerializeField]
    private PlayerCtrl _playerCtrl;

    private const string HP = "HP";
    private const string MP = "MP";
    private const string SlowHP = "SlowHP";

    public void UseItem(Items _item)
    {
        if (_item.itemType == Items.ItemType.Used)
        {
            for (int i = 0; i < itemEffects.Length; i++)
            {
                if (itemEffects[i].itemName == _item.itemName)
                {
                    for (int j = 0; j < itemEffects[i].part.Length; j++)
                    {
                        switch (itemEffects[i].part[j])
                        {
                            case HP:
                                _playerCtrl.IncreaseHP(itemEffects[i].num[j]);
                                break;
                            case MP:
                                _playerCtrl.IncreaseMP(itemEffects[i].num[j]);
                                break;
                            case SlowHP:
                                _playerCtrl.IncreaseSlowHP(itemEffects[i].num[j]);
                                break;
                            default:
                                Debug.Log("잘못된 효과 적용");
                                break;
                        }
                    }
                    return;
                }
            }
            Debug.Log("일치하는 아이템이 없습니다.");
        }
    }
}
