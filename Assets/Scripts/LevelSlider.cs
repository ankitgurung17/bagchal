using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
   
    public GameObject[] characterList;
    private int index;
   

    private void Start()
    {
        characterList = new GameObject[transform.childCount];

        //Fill the array with our models
        for (int i = 0; i < transform.childCount; i++)

            characterList[i] = transform.GetChild(i).gameObject;

        //We toggle off their render
        foreach (GameObject go in characterList)
            go.SetActive(false);

        //We toggle on the first index
         if (characterList[0])
            characterList[0].SetActive(true);

    }
    public void ToggleLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = characterList.Length - 1;

        characterList[index].SetActive(true);

     

    }
    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
            index = 0;

        characterList[index].SetActive(true);

    }


}
