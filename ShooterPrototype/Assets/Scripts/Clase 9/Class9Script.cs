using UnityEngine;


public interface IAttackable
{
    bool IsAlive { get; }
    void TakeDamage(int amount);
}


public abstract class Character : MonoBehaviour, IAttackable
{
    public string Name { get; }
    private int health;
    public int Health { get => health; protected set => health = Mathf.Max(0, value); }


    public bool IsAlive => Health > 0;

    protected Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public virtual void TakeDamage(int amount)
    {
        Health -= amount;
        if (!IsAlive) OnDeath();
    }

    protected virtual void OnDeath()
    {
        Debug.Log("Se murio");
    }

    public abstract void Attack(IAttackable target);
}

public class Player : Character
{
    public Player(string name, int health) : base(name, health) { }

    public override void Attack(IAttackable target)
    {
        Debug.Log($"{Name} ataco!");
        target.TakeDamage(100);
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        Debug.Log($"{Name} recibio {amount} de daño. Salud: {Health}");
    }

}

public class Enemy2 : Character
{
    public Enemy2(string name, int health) : base(name, health) { }

    public override void Attack(IAttackable target)
    {
        Debug.Log($"{Name} ataco!");
        target.TakeDamage(100);
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        Debug.Log($"{Name} recibio {amount} de daño. Salud: {Health}");
    }
    
    protected override void OnDeath()
    {
        Debug.Log($"{Name} se murio");
    }
}



public class Class9Script : MonoBehaviour
{
    private void Start()
    {
        Player player1 = new Player("ElDamo", 100);
        Enemy2 enemy = new Enemy2("Destructor", 100);
        player1.Attack(enemy);
        enemy.Attack(player1); 
    }
}
