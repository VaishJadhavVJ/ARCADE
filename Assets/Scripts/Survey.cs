using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Survey : MonoBehaviour
{
    InputField feedback1;
    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf8GpfcCPTcAh3WBolChxfxywFjdilwmvdRRi5ECb7Sat7tCg/formResponse";

    void Start()
    {
        // Find the InputField dynamically by its path in the hierarchy
        Transform inputFieldTransform = transform.Find("Panel/InputField");
        if (inputFieldTransform != null)
        {
            feedback1 = inputFieldTransform.GetComponent<InputField>();
            if (feedback1 == null)
            {
                Debug.LogError("InputField component not found on the GameObject named 'InputField'.");
            }
        }
        else
        {
            Debug.LogError("InputField GameObject not found in the hierarchy. Make sure it's named and placed correctly.");
        }
    }

    public void Send()
    {
        if (feedback1 != null)
        {
            StartCoroutine(Post(feedback1.text));
        }
        else
        {
            Debug.LogError("InputField not found! Make sure it's named correctly.");
        }
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1965787648", s1);
        
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
