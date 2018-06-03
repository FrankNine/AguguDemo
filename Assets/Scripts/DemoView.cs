using UnityEngine;
using UnityEngine.UI;

using Zenject;
using  UniRx;

public class DemoView : MonoBehaviour
{
    [Inject(Id = "IncButton")] private Button _increaseButton;
    [Inject(Id = "DecButton")] private Button _decreaseButton;
    [Inject(Id = "PointText")] private Text   _pointText;

    [Inject] private DemoViewModel _viewModel;
    [Inject] IncreaseRequestedSignal _increaseRequestedSignal;
    [Inject] DecreaseRequestedSignal _decreaseRequestedSignal;

    private void Start()
    {
        _increaseButton.onClick.AddListener(_increaseRequestedSignal.Fire);
        _decreaseButton.onClick.AddListener(_decreaseRequestedSignal.Fire);
        _viewModel.DisplayText.Subscribe(displayText => _pointText.text = displayText);
    }
}
