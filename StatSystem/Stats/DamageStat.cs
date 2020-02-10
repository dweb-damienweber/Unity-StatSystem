using UnityEngine;

public class DamageStat : Stat
{
    #region Constructors

    public DamageStat(float minValue, float maxValue, float minLimit, float maxLimit)
    {
        _baseStatValueMin = minValue;
        _baseStatValueMax = maxValue;

        _minValueLimit = minLimit;
        _maxValueLimit = maxLimit;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Return only the second base value
    /// </summary>
    public float GetBaseValueMax()
    {
        return _baseStatValueMax;
    }

    protected override void Calc()
    {
        _totalStatValue = Random.Range(_baseStatValueMin, _baseStatValueMax);

        // Apply stat modifiers
        _totalStatValue += _statModifierAdd;
        _totalStatValue *= 1 + (_statModifierMult / 100);

        _totalStatValue = Mathf.Clamp(_totalStatValue, _minValueLimit, _maxValueLimit);
        _totalStatValue = Mathf.RoundToInt(_totalStatValue);
    }

    #endregion


    #region Private fields

    private float _baseStatValueMax;

    #endregion
}
