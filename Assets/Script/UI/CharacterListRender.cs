using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListRender : MonoBehaviour
{
    [SerializeField]
    GameObject content;
    [SerializeField]
    GameObject characterCard;

    private void Start()
    {
        renderList();
    }

    public void renderList()
    {   
        List<BaseCharacterStats> characters = CharacterManager.Instance().GetListCharacter();
        foreach (BaseCharacterStats character in characters)
        {
            addCard(character);
        }
    }

    public void addCard(BaseCharacterStats character)
    {
        GameObject card = Instantiate(characterCard, new Vector3(0, 0, 0), Quaternion.identity);

        CharacterCardBinding binding = card.GetComponent<CharacterCardBinding>();
        binding.txtName.text = character.name;
        binding.txtHP.text = "" + character.hp;
        binding.txtMP.text = "" + character.mp;
        binding.txtATK.text = "" + character.atk;
        binding.txtDEF.text = "" + character.def;
        binding.txtSPD.text = "" + character.speed;

        card.transform.SetParent(content.transform);
        card.transform.localPosition = new Vector3();
        card.transform.localScale = new Vector3(1f, 1f, 1f);
        card.transform.localRotation = Quaternion.Euler(new Vector3());
        card.name = character.name;
    }
}
