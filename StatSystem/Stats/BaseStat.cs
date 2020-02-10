using UnityEngine;

public class BaseStat : Stat
{
    #region Constructors

    public BaseStat(float baseValueMin, float minLimit, float maxLimit)
    {
        _baseStatValueMin = baseValueMin;
        _totalStatValue = baseValueMin;

        _minValueLimit = minLimit;
        _maxValueLimit = maxLimit;
    }

    #endregion


    #region Methods

    protected override void Calc()
    {
        _totalStatValue = _baseStatValueMin;

        // Apply stat modifiers
        _totalStatValue += _statModifierAdd;
        _totalStatValue *= 1 + (_statModifierMult / 100);

        _totalStatValue = Mathf.Clamp(_totalStatValue, _minValueLimit, _maxValueLimit);
        _needCalc = false;
    }

    #endregion
}
