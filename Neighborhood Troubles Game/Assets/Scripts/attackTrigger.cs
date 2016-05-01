using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
    }

}
