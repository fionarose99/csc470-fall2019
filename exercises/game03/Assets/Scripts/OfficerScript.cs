using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerScript : MonoBehaviour
{
    // Movement, Collisions, Particle Effects
    // ******
    // Add particle effects for the secret
    // Kinematic rigidbody + CapsuleCollider with isTrigger for collisions
    // Extra CapsuleCollider without isTrigger so don't fall through floor
    // CharacterController to ensure slide-past movement
    // If Collision w/ Finch for time > touchTime, start CHASE
    // If Collision w/ Finch then pop letter off stack
    // If right color, fill ReadyToGo meter--if wrong color, subtract from ReadyToGo meter

    // TAGS
    // ******
    // Rosemary--magenta--Steno Pool (ally)
    // Ovington--yellow--Advertising (enemy)
    // Gatch--cyan--Plans and Systems (enemy)
    // Bud Frump--green--Exec Mail (enemy)
    // Smitty--red--Personnel (ally)
    // Twimble--blue--Mailroom (tutorial, ally)

    // Meters and Timers
    // ******
    // METER - ReadyToGo filled by Letters Delivered
    // Triggered by collisions w/ Finch when carrying letters
    // TIMER - Waiting
    // METER - Happy
    // TIMER - ComeBack (after leaving mailroom for re-enter (back-end; not visible))
    // When ComeBack = Done, re-enter mailroom, restart Waiting, reset ReadyToGo
    // When Waiting runs out, leave mailroom.
    // When Leave, if ReadyToGo meter filled, HAPPY + 20/100
    // When Leave, if ReadyToGo meter NOT filled, not HAPPY - 20/100


    // Start is called before the first frame update

    public Vector3 startPos;
    public Vector3 startRotVector;
    CharacterController cc;
    public Renderer rend;
    private Vector3 destination;
    GameManager gm;

    void Start()
    {
        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();

        cc = gameObject.GetComponent<CharacterController>();

        transform.position = startPos; // startPos set in inspector view
        Quaternion startRotQuat = Quaternion.Euler(startRotVector); // convert startRotVector set in inspector to Quaternion for actual use
        destination = transform.position; // set destination (effectively) to startPos

        InvokeRepeating("UpdateDestination", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate and move towards destination
        if (destination != null && Vector3.Distance(destination, transform.position) > 0.5f)
        {
            destination.y = transform.position.y;
            Vector3 vecToDest = (destination - transform.position).normalized;
            float step = 3 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, vecToDest, step, 1);
            transform.rotation = Quaternion.LookRotation(newDir);

            cc.Move(transform.forward * 5 * Time.deltaTime);
        }

    }

    private void UpdateDestination()
    {
        destination = new Vector3(Random.Range(-21.5f, 21.5f), 0, Random.Range(-21.5f, 21.5f));
    }
}
