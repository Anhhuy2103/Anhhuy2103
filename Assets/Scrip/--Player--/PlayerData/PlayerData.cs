
using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName = "PlayerData" )]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string PlayerName;
    public string Name
    {
        get => PlayerName;
        private set => PlayerName = value;
    }

    [SerializeField] private int MaxHP;
    public int _MaxHp
    {
        get => MaxHP;
        private set => MaxHP = value;
    }

    [SerializeField] private int CurrentHP;
    public int _CurrentHP
    {
        get => CurrentHP;
        private set => CurrentHP = value;
    }

    [SerializeField] private int basicDame;
    public int BasicDame
    {
        get => basicDame;
        private set => basicDame = value;
    }

    public PlayerData(string name, int HP, int dame)
    {
        this.Name = name;
        this._MaxHp = HP;
        this.BasicDame = dame;
    }

    public void AddDame(int value)
    {
        this.basicDame += value;
    }

    public void AddHP(int Health)
    {
       if(CurrentHP < 0)
        {
            this.CurrentHP += Health;
        }
        else
        {
            this.CurrentHP = this.MaxHP;
        }
    }

    public void ResetHP()
    {
        this.CurrentHP = this.MaxHP;
    }
}
