using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthComponent
{
    [Header("Stats")]
    public float MaxHP = 100;
    public float Damage = 20;
    public float AttackSpeed = 1.0f;
    public float AttackRange = 1.4f;
    public float MovementSpeed = 3f;
    public float DistanceOfSight = 15;

    public float CurrentHP = 0;

    [HideInInspector] public UnitStatsReadOnly UnitStats;

    public HealthComponent()
    {
        CurrentHP = MaxHP;
        UnitStats = new UnitStatsReadOnly(this);
    }

    public HealthStatus RecieveDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP > 0) return HealthStatus.Alive;
        else return HealthStatus.Dead;
    }

    public enum HealthStatus
    {
        Alive = 0,
        Dead = 1
    }


    public class UnitStatsReadOnly
    {
        public float MaxHP { get { return sourceStatsReference.MaxHP; } }
        public float Damage { get { return sourceStatsReference.Damage; } }
        public float AttackSpeed { get { return sourceStatsReference.AttackSpeed; } }
        public float AttackRange { get { return sourceStatsReference.AttackRange; } }
        public float MovementSpeed { get { return sourceStatsReference.MovementSpeed; } }
        public float DistanceOfSight{ get { return sourceStatsReference.DistanceOfSight; } }
        public float CurrentHP { get { return sourceStatsReference.CurrentHP; } }


        private HealthComponent sourceStatsReference;

        internal UnitStatsReadOnly(HealthComponent healthComponent)
        {
            sourceStatsReference = healthComponent;
        }

        

    }
}
