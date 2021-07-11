using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public AnimationCurve curve;
    public AnimationCurve sizeCurve;

    private Vector3 _start;

    private float _time;
    private Vector3 _target;
    private Transform _player;
    private Transform[] _playerBody;
    private Boolean _coolDown;

    private void Start()
    {
        _start = transform.position;
        //_player = GameObject.Find("snake").transform.GetChild(0).gameObject.transform;
        _player = GameObject.Find("snake").transform;
        _playerBody = _player.GetComponentsInChildren<Transform>();


        _target = _player.transform.GetChild(Random.Range(0, _playerBody.Length-2)).position;
        StartCoroutine(Curve());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_time > 1.5f)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            if (other.gameObject.name.Contains("Body") && !_coolDown)
            {
                StartCoroutine("Cooldown");
                other.gameObject.GetComponentInParent<snake>().hp -= 1;
            }
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
    }

    private IEnumerator Cooldown()
    {
        _coolDown = true;
        yield return new WaitForSeconds(1f);
        _coolDown = false;
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
