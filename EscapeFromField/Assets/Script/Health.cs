using UnityEngine;

public class Health : MonoBehaviour
{
    private int hpPoint = 20; // 현제 체력
    private int maxHpPoint = 100;

    private int mpPoint = 100;
    private int maxMpPoint = 100;
    
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //플레이어의 상태를 반환
    public int GetHealth()
    {
        return hpPoint;
    }

    public int GetMana()
    {
        return mpPoint;
    }
    
    public int GetMaxHealth()
    {
        return maxHpPoint;
    }

    public int GetMaxMana()
    {
        return maxMpPoint;
    }
    
    //아이템 사용으로 최대 체력을 늘림
    public void SetMaxHealth(int health)
    {
       
    }

    public void SetMaxMana(int mana)
    {
        
    }
}
