public class ResourceStat : BaseStat
{
    #region Constructors

    public ResourceStat(float currentValue, float baseValue, float minLimit, float maxLimit) : base(baseValue, minLimit, maxLimit)
    {
        _currentValue = currentValue;
    }

    #endregion


    #region Methods

    /// <summary>
    /// Return the current value of the stat (Not the total)
    /// </summary>
    public float GetCurrentValue()
    {
        return _currentValue;
    }

    #endregion


    #region Private fields

    private float _currentValue = 0f;

    #endregion
}
