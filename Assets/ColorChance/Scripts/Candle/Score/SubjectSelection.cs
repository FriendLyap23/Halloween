using UnityEngine;

public class SubjectSelection : MonoBehaviour
{
    [SerializeField] private ChangeScore _changeScore;

    private void OnTriggerEnter(Collider collision)
    {
        _changeScore.SubscribeToAddScoreDelegate();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _changeScore._scoreHandler?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _changeScore.UnsubscribeToAddScoreDelegate();
    }

}