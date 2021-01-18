using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContatinerController : MonoBehaviour
{
    [SerializeField] Transform effectPosition;
    [SerializeField] GameObject effect;
    private List<String> rightBoxes;
    private List<String> containerItems;
    [SerializeField] private List<GameObject> panels;
    void Start()
    {
        rightBoxes = new List<String>{ "</html>", "</body>", "<body>", "</head>", "<head>", "<html>" };
        containerItems = new List<String>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("Player"))
        {
            collision.transform.position = Vector3.up;
            Instantiate(effect, effectPosition);
            collision.GetComponent<CharacterController>().PlayEffect();
        }

        containerItems.Add(collision.transform.name);

        for (int i = 0; i < containerItems.Count; i++)
        {
            if (!containerItems[i].Equals(rightBoxes[i]))
            {
                Debug.Log($"Ну удаляю {containerItems[i]}");
                collision.transform.position = Vector3.up;
                containerItems.RemoveAt(i);
            }
            else
            {
                panels[i].SetActive(true);
            }
        }
        
    }

}
