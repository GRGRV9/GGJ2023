using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public IntroScript introScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<MovementController>().IsDead() == false)
        {
            introScript.WinLevel();
            collision.GetComponent<MovementController>().BlockInput();
            collision.GetComponent<MovementController>().startSpeed = 0;
            collision.GetComponent<SpellController>().BlockInput();
        }
    }
}
