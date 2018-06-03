using Zenject;
using UniRx;

public class DemoPresenter : IInitializable
{
    private readonly DemoViewModel           _viewModel;
    private readonly IncreaseRequestedSignal _increaseRequestedSignal;
    private readonly DecreaseRequestedSignal _decreaseRequestedSignal;

    private int _point;

    public DemoPresenter
    (
        DemoViewModel viewModel,
        IncreaseRequestedSignal increaseRequestedSignal,
        DecreaseRequestedSignal decreaseRequestedSignal
    )
    {
        _viewModel = viewModel;

        _increaseRequestedSignal = increaseRequestedSignal;
        _decreaseRequestedSignal = decreaseRequestedSignal;

        _point = 0;
    }

    public void Initialize()
    {
        _increaseRequestedSignal.AsObservable.Subscribe(_ =>
        {
            _point++;
            _UpdateView();
        });

        _decreaseRequestedSignal.AsObservable.Subscribe(_ =>
        {
            _point--;
            _UpdateView();
        });
    }

    private void _UpdateView()
    {
        _viewModel.DisplayText.Value = string.Format("Point: {0}", _point);
    }
}

public class IncreaseRequestedSignal : Signal<IncreaseRequestedSignal> { }
public class DecreaseRequestedSignal : Signal<DecreaseRequestedSignal> { }

public class DemoViewModel
{
    public ReactiveProperty<string> DisplayText { get; set; }

    public DemoViewModel()
    {
        DisplayText = new ReactiveProperty<string>("Please press a button");
    }
}