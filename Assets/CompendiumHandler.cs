using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompendiumHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] pageList;
    private int currentPage;
    [SerializeField] private GameObject prevArrow;
    [SerializeField] private GameObject nextArrow;
    [SerializeField] private Animation pageAnimation;
    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        updatePage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementPage(int count)
    {
        int nextPage = currentPage + count;
        if (nextPage >= 0 && nextPage < pageList.Length)
        {
            currentPage = nextPage;
            Debug.Log("Current page:" + currentPage);
            updatePage();
        }
        else
        {
            Debug.Log("Page is out of bounds");
        }
        //pageAnimation.Play();
        //Debug.Log("Playing animation");
    }

    public void updatePage()
    {
        for (int i = 0; i < pageList.Length; i++)
        {
            if (i == currentPage)
            {
                pageList[i].SetActive(true);
            }
            else
            {
                pageList[i].SetActive(false);
            }
        }
        if (currentPage == 0)
        {
            prevArrow.SetActive(false);
            nextArrow.SetActive(true);
        }
        else if (currentPage == pageList.Length)
        {
            prevArrow.SetActive(true);
            nextArrow.SetActive(false);
        }
        else
        {
            prevArrow.SetActive(true);
            nextArrow.SetActive(true);
        }
    }
}
