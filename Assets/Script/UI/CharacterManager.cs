using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    List<BaseCharacterStats> characters = new List<BaseCharacterStats>();

    private static CharacterManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        FileManager fileManager = new FileManager(FileName.FILE_SAVE);
        characters = fileManager.ReadCharacterFromFile();
    }

    public static CharacterManager Instance()
    {
        return instance;
    }

    public List<BaseCharacterStats> GetListCharacter()
    {
        return characters;
    }

    public void addCharacter(BaseCharacterStats character)
    {
        characters.Add(character);
    }
}
