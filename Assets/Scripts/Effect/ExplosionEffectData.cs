using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JASS Data/Effect/Explosion Effect")]
public class ExplosionEffectData : EffectData
{
    [Header("ExplosionEffectData")]
    [SerializeField] private DiceRoll damage;
    [SerializeField][Min(0)] private int radius;
    [SerializeField][Range(0F, 1F)] private float falloff;
    public DiceRoll Damage { get => damage; private set => damage = value; }
    public int Radius { get => radius; private set => radius = value; }
    public float Falloff { get => falloff; private set => falloff = value; }

    public override bool Apply(Character actor, Item item, Vector3 position, Character target)
    {
        LevelGrid levelGrid = LevelController.Instance.GetLevelGrid();
        Vector3Int center = levelGrid.GetGridPosition(position);
        List<LevelTile> tileList = LevelGridHelper.GetFromRadius(levelGrid, center, Radius);
        foreach (LevelTile tile in tileList)
        {
            Vector3Int gridPosition = tile.GridPosition;
            float radiusAux = (Radius - gridPosition.magnitude) / Radius;
            float falloffAux = 1 - (Falloff * radiusAux);
            int damage = Damage.Roll();
            int damageAux = Mathf.RoundToInt(damage * falloffAux);
            tile.Character.TakeDamage(damageAux);
        }
        return true;
    }
}
