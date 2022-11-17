using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth; // 플레이어 최대 체력
    private int maxMana; // 플레이어 최대 마나
    
    private int currentHealth; //플레이어 현제 체력
    private int currentMana; //플레이어 현제 마나

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        maxMana = 100;
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //현제 플레이어의 상태를 반환
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }

    //플레이어의 상태를 반환
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetMaxMana()
    {
        return maxMana;
    }
    
    //아이템 사용으로 최대 체력을 늘림
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
    }

    public void SetMaxMana(int mana)
    {
        maxMana = mana;
    }
}
