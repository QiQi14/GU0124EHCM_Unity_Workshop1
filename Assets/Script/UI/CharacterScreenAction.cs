using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterScreenAction : MonoBehaviour
{
    [SerializeField]
    GameObject characterInfoPanel;
    [SerializeField]
    GameObject characterCardsContainer;

    public void onClickAddCharacter()
    {
        characterInfoPanel.SetActive(true);
    }

    public void onClickCloseInfo()
    {
        characterInfoPanel.SetActive(false);
    }

    public void onClickSave()
    {
        FormBinding form = characterInfoPanel.GetComponent<FormBinding>();

        BaseCharacterStats character = new BaseCharacterStats();
        character.name = form.ipName.text;
        character.hp = (float)Convert.ToDecimal(form.ipHP.text);
        character.mp = (float)Convert.ToDecimal(form.ipMP.text);
        character.atk = (float)Convert.ToDecimal(form.ipATK.text);
        character.def = (float)Convert.ToDecimal(form.ipDEF.text);
        character.speed = (float)Convert.ToDecimal(form.ipSPD.text);

        CharacterManager.Instance().addCharacter(character);
        CharacterListRender listRender = characterCardsContainer.GetComponent<CharacterListRender>();
        listRender.addCard(character);
        string json = JsonConvert.SerializeObject(CharacterManager.Instance().GetListCharacter(), Formatting.Indented);

        FileManager fileManager = new FileManager(FileName.FILE_SAVE);
        fileManager.WriteToFile(json);

        characterInfoPanel.SetActive(false);
    }
}
