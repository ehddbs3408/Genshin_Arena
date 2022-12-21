using UnityEngine;

[CreateAssetMenu(menuName = "SO/Drawing/PossibilityData")]
public class DrawingWeaponPossibility : ScriptableObject
{
    [Range(0, 100)]
    public float oneStartPossibility;
    [Range(0, 100)]
    public float twoStartPossibility;
    [Range(0, 100)]
    public float threeStartPossibility;
    [Range(0, 100)]
    public float fourStartPossibility;
    [Range(0, 100)]
    public float fiveStartPossibility;
}