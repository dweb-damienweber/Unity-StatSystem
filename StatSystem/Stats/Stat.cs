/// <summary>
/// Base class for all stat type
/// </summary>
public abstract class Stat
{
    #region Methods

    /// <summary>
    /// Return only the base value
    /// </summary>
    public float GetBaseValueMin()
    {
        return _baseStatValueMin;
    }

    /// <summary>
    /// Add a modifier to the stat
    /// </summary>
    public virtual void AddStatModifier(EStatModifierType modifierType, float value)
    {
        if (modifierType == EStatModifierType.MORE || modifierType == EStatModifierType.LESS)
            _statModifierAdd += value;
        else if (modifierType == EStatModifierType.INCREASE || modifierType == EStatModifierType.DECREASE)
            _statModifierMult += value;

        _needCalc = true;
    }

    /// <summary>
    /// Remove a modifier to the stat
    /// </summary>
    public void RemoveStatModifier(EStatModifierType modifierType, float value)
    {
        if (modifierType == EStatModifierType.MORE || modifierType == EStatModifierType.LESS)
            _statModifierAdd -= value;
        else if (modifierType == EStatModifierType.INCREASE || modifierType == EStatModifierType.DECREASE)
            _statModifierMult -= value;

        _needCalc = true;
    }

    /// <summary>
    /// Return the calculated value of the stat
    /// </summary>
    public float GetValue()
    {
        if (_needCalc)
            Calc();

        return _totalStatValue;
    }

    /// <summary>
    /// Calculate the stat (with modifiers)
    /// </summary>
    protected abstract void Calc();

    #endregion


    #region Private fields

    // Base value
    protected float _baseStatValueMin = 0;

    // Modifiers
    protected float _statModifierAdd = 0;
    protected float _statModifierMult = 0;

    // Final value
    protected bool _needCalc = true;
    protected float _totalStatValue = 0;

    // Cap values
    protected float _minValueLimit = 0;
    protected float _maxValueLimit = 0;

    #endregion
}
