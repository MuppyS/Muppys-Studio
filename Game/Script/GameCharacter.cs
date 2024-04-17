using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameCharacter : MonoBehaviour
{

    int index = 0;
    [SerializeField] List<GameObject> players = new List<GameObject>();
    PlayerInputManager manager;

    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        index = 0;
        manager.playerPrefab = players[index];
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        index += 1;
        manager.playerPrefab = players[index];
    }
}
