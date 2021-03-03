using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] Transform AimPoint;
    private playerScript player;
    private Animator shootAnimator; // When animations are ready go to awake

    private void Awake()
    {
        player = GetComponent<playerScript>();
        //shootAnimator = AimPoint.GetComponent<Animator>();
    }

    private void Update()
    {
        AimFunction();
    }

    private void AimFunction()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        float angle = AngleBetweenPoints(AimPoint.position, mouseWorldPosition);
        AimPoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));     

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);
        direction.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            player.rigidbody.AddForce(-direction * player.Knockback, ForceMode.Impulse);

            print(angle);
            print("knockback = " + player.Knockback);
            print("object = " + player.rigidbody);
        }
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }









}
