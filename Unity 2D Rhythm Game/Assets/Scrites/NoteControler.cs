using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControler : MonoBehaviour
{

    class Note
    {
        public int noteType { get; set; }
        public int order { get; set; }
        public Note(int noteType,int order)
        {
            this.noteType = noteType;
            this.order = order;
        }
    }

    public GameObject[] Notes;

    private ObjectPooler noteObjectPooler;
    private List<Note> notes = new List<Note>();
    private float x, z, startY = 8.0f;
    private float beatInterval = 1.0f;

    void MakeNote(Note note)
    {
        GameObject obj = noteObjectPooler.getObj(note.noteType);
        x = obj.transform.position.x;
        z = obj.transform.position.z;
        obj.transform.position = new Vector3(x, startY, z);
        obj.GetComponent<NoteBehavior>().Initialize();
        obj.SetActive(true);

    }

    IEnumerator AwaitMakeNote(Note note)
    {
        int noteType = note.noteType;
        int order = note.order;
        yield return new WaitForSeconds(order*beatInterval);
        MakeNote(note);
    }

    // Start is called before the first frame update
    void Start()
    {
        noteObjectPooler = gameObject.GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
