using UnityEngine;

public class SpendObjects : MonoBehaviour
{
    [SerializeField] private SubjectSelection _subjectSelection;
    [SerializeField] private ChangeScore _changeScore;

    private void OnTriggerStay(Collider other)
    {
        _changeScore.SubscribeToSpendScore();
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && Input.GetAxis("Interactions") == 1)
            _changeScore._scoreHandler?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        _changeScore.UnsubscribeToSpendScore();
    }
}
