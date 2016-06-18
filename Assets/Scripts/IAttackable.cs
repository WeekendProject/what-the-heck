using UnityEngine;
using System.Collections;

public interface IAttackable
{
    void OnAttack(IAttacker attacker);
}
