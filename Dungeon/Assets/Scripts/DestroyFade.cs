using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFade : MonoBehaviour
{
    [SerializeField] private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade() {
        yield return new WaitForSeconds(lifetime);

        float blinkTime = .3f;

        for(int i = 0; i < 8; i++)
        {
            foreach(MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>()) {
                mr.enabled = false;
                Debug.Log("Disabling");
            }

            yield return new WaitForSeconds(blinkTime);

            foreach(MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>()) {
                mr.enabled = true;
                Debug.Log("Enabling");
            }

            yield return new WaitForSeconds(blinkTime);

            blinkTime -= .03f;
        }

        Destroy(gameObject);
    }
}
