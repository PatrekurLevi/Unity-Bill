using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    // Mig langaði að minni bestu getu að búa til hindranir sem myndu klessa á mann.
    // Það átti upprunarlega að vera að færa sig frá hægri og vinstri (X-ásinn).
    // Ég fékk eina loop-u til að framkvæma það en það færðist alltaf frá sinni stöðu og alveg upp að playernum.
    // Þannig að í endann endaði ég á því bara að taka þessa flækju út og skila þessu bara eins og það á að vera.
    public Vector3 pointB;

    IEnumerator Start()
    {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}