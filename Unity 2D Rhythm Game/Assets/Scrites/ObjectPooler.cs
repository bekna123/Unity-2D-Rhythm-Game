using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public List<GameObject> notes;//타입저장용
    private List<List<GameObject>> poolsOfNotes;
    public int noteCount = 10;
    private bool more = true;

    // Start is called before the first frame update
    void Start()
    {
        poolsOfNotes = new List<List<GameObject>>();
        for (int i = 0; i < notes.Count; i++)
        {
            poolsOfNotes.Add(new List<GameObject>());
            for (int j = 0; i < noteCount; j++)
            {
                GameObject obj = Instantiate(notes[i]);
                obj.SetActive(false);
                poolsOfNotes[i].Add(obj);
            }
        }
    }
    
    public GameObject getObj(int type)
    {
        foreach(GameObject obj in poolsOfNotes[type - 1])
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        if (more)
        {
            GameObject obj = Instantiate(notes[type - 1]);
            return obj;
        }
        return null;
    }
}
