using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    
    public List<Transform> bodyParts = new List<Transform>();

    public float minDistance = 0.25f;
    public int beginSize;
    public GameObject bodyPrefab;
    public float movementSpeed;

    private float _dis;
    private Transform _curBodyPart;
    private Transform prevBodyPart;
    
    void Start()
    {
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
    }
    
    public void AddBodyPart()
    {
        Transform newPart =
            (Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].position,
                bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newPart.SetParent(transform);
        bodyParts.Add(newPart);
    }
    
    void FixedUpdate()
    {
        Debug.Log(bodyParts.Count);
        for (int i = 1; i < bodyParts.Count; i++)
        {
            _curBodyPart = bodyParts[i];
            prevBodyPart = bodyParts[i - 1];
            int m = i;
            while (_curBodyPart == null)
            {
                bodyParts.Remove(bodyParts[i]);
                _curBodyPart = bodyParts[m];
                m++;
            }
            while (prevBodyPart == null)
            {
                bodyParts.Remove(bodyParts[i - 1]);
                prevBodyPart = bodyParts[m - 1];
                m--;
            }

            _dis = Vector2.Distance(prevBodyPart.position, _curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;
            
            float t = Time.deltaTime * _dis / minDistance * movementSpeed;
            
            if (t > 0.5f)
            {
                t = 0.5f;
            }

            _curBodyPart.position = Vector3.Slerp(_curBodyPart.position, newPos, t);
            _curBodyPart.rotation = Quaternion.Slerp(_curBodyPart.rotation, prevBodyPart.rotation, t);
        }
    }
}
