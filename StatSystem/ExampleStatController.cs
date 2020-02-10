using System.Collections.Generic;
using UnityEngine;

public class ExampleStatController : MonoBehaviour
{
    #region System methods

    private void Awake()
    {
        InitStats();
    }

    #endregion


    #region Methods

    /// <summary>
    /// Initialize the base stats of this object
    /// </summary>
    private void InitStats()
    {
        _stats = new Dictionary<EStatType, Stat>();

        // Resources
        _stats.Add(EStatType.HEALTH, new ResourceStat(100f, 100f, 1, 9999f));
        _stats.Add(EStatType.MANA, new ResourceStat(100f, 100f, 1, 9999f));

        // Damages
        _stats.Add(EStatType.PHYSICAL_DMG, new DamageStat(1f, 1f, 0f, 9999f));
        _stats.Add(EStatType.FIRE_DMG, new DamageStat(1f, 1f, 0f, 9999f));
        _stats.Add(EStatType.COLD_DMG, new DamageStat(1f, 1f, 0f, 9999f));
        _stats.Add(EStatType.LIGHTNING_DMG, new DamageStat(1f, 1f, 0f, 9999f));

        // Resistances
        _stats.Add(EStatType.PHYSICAL_RES, new BaseStat(1f, -100f, 100f));
        _stats.Add(EStatType.FIRE_RES, new BaseStat(1f, -100f, 100f));
        _stats.Add(EStatType.COLD_RES, new BaseStat(1f, -100f, 100f));
        _stats.Add(EStatType.LIGHTNING_RES, new BaseStat(1f, -100f, 100f));

        // Other stats
        _stats.Add(EStatType.MOVEMENT_SPEED, new BaseStat(5f, 0f, 50f));
        _stats.Add(EStatType.ATTACK_SPEED, new BaseStat(1f, .1f, 10f));
    }

    /// <summary>
    /// Add a modifier to a specific stat
    /// </summary>
    private void AddBonusToStat(EStatType statType, EStatModifierType bonusType, float bonusValue)
    {
        if (_stats.ContainsKey(statType))
        {
            _stats[statType].AddStatModifier(bonusType, bonusValue);
        }
    }

    /// <summary>
    /// Remove a modifier from a specific stat
    /// </summary>
    private void RemoveBonusFromStat(EStatType statType, EStatModifierType bonusType, float bonusValue)
    {
        if (_stats.ContainsKey(statType))
        {
            _stats[statType].RemoveStatModifier(bonusType, bonusValue);
        }
    }

    #endregion


    #region Private fields

    private Dictionary<EStatType, Stat> _stats;

    #endregion
}
