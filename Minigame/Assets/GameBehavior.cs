using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trashcanPrefab;
    public int trashcanAmount = 3;
    public Vector2 spawnRangeY = new Vector2(-2f, 2f);
    public Vector2 trashcanLengthRange = new Vector2(0.5f, 2f);
    
    private Color[] colors = { Color.red, Color.green, Color.yellow };

    void Start()
    {
        ShuffleColors();
        
        /*for (int i = 0; i < trashcanAmount; i++)
        {
            SpawnTrashCan(i);
        }*/
        
        float spacing = 5.0f; // Define the distance between the trash cans

        for (int i = 0; i < 3; i++)
        {
            float xOffset = i * spacing; // Adjust x position for each trash can
            SpawnTrashCan(i, xOffset);
        }
    }

    /*void SpawnTrashCan(int index)
    {
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);

        // Instantiate the trashcan
        GameObject newTrashcan = Instantiate(trashcanPrefab, spawnPosition, Quaternion.identity);

        // Randomize the trashcan length (scale)
        float randomLength = Random.Range(trashcanLengthRange.x, trashcanLengthRange.y);
        newTrashcan.transform.localScale = new Vector3(newTrashcan.transform.localScale.x, randomLength, newTrashcan.transform.localScale.z);

        // Randomize the color
        newTrashcan.GetComponent<SpriteRenderer>().color = colors[index];
    }*/
    
    void SpawnTrashCan(int index, float xOffset)
    {
        // float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
        Vector3 spawnPosition = new Vector3(-3.5f + xOffset, -4, 0);

        // Instantiate the trashcan
        GameObject newTrashcan = Instantiate(trashcanPrefab, spawnPosition, Quaternion.identity);
        newTrashcan.tag = "TrashCan";

        // Randomize the trashcan length (scale)
        float randomLength = Random.Range(3, 10);
        newTrashcan.transform.localScale = new Vector3(newTrashcan.transform.localScale.x, randomLength, newTrashcan.transform.localScale.z);

        // Randomize the color
        newTrashcan.GetComponent<SpriteRenderer>().color = colors[index];
    }
    // Update is called once per frame
    
    void ShuffleColors()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            Color temp = colors[i];
            int randomIndex = Random.Range(i, colors.Length);
            colors[i] = colors[randomIndex];
            colors[randomIndex] = temp;
        }
    }
    void Update()
    {
        
    }
}
