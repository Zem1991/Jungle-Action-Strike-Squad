using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    [SerializeField] private PlayerType playerType;

    private void Start()
    {
        Player player = null;
        //Color color = Color.white;

        if (playerType == PlayerType.LOCAL)
        {
            player = FindObjectOfType<LocalPlayer>();
            //color = Color.blue;
        }
        else if (playerType == PlayerType.ENEMY)
        {
            player = FindObjectOfType<EnemyPlayer>();
            //color = Color.red;
        }

        List<Character> characterList = GetComponentsInChildren<Character>().ToList();
        player.AddCharacters(characterList);
    }
}
