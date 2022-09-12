using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    [SerializeField] private PlayerType playerType;

    private void Start()
    {
        List<Character> characterList = GetComponentsInChildren<Character>().ToList();
        if (playerType == PlayerType.LOCAL)
        {
            FindObjectOfType<LocalPlayer>().AddCharacters(characterList);
        }
        else if (playerType == PlayerType.ENEMY)
        {
            FindObjectOfType<EnemyPlayer>().AddCharacters(characterList);
        }
    }
}
