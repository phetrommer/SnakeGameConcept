using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class bulletscript : MonoBehaviour
{
    public GameObject hitEffect;
    public AnimationCurve curve;
    public AnimationCurve sizeCurve;
    private Camera _cam;

    private Vector3 _start;

    private Vector3 _target;
    private float _time;

    private void Awake()
    {
        _start = transform.position;
        _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        _target = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        StartCoroutine(Curve());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_time > 1.5f)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            if (other.name.Contains("Body"))
            {
                other.GetComponent<body>().hp -= 10;
            }
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
    }

    private IEnumerator Curve()
    {
        var duration = 2f;
        _time = 0f;

        Vector3 end = _target;

        while (_time < duration)
        {
            _time += Time.deltaTime;

            var linearT = _time / duration;
            var heightT = curve.Evaluate(linearT);
            transform.localScale = sizeCurve.Evaluate(linearT) * Vector3.one;

            var height = Mathf.Lerp(0f, 3.0f, heightT); // arc height
            transform.position = Vector2.Lerp(_start, end, linearT) + new Vector2(0f, height);

            yield return null;
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        Destroy(gameObject);
    }
}