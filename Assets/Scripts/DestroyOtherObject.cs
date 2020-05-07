using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherObject : MonoBehaviour
{
    public GameObject other;
    public GameObject dialogManager;

    public void delete()
    {
        Destroy(other);
    }

    public void enableDialog()
    {
        dialogManager.GetComponent<DialogueManager>().enabled = true;
    }
}
