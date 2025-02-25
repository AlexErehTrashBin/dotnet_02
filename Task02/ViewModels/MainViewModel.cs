using System.Runtime.CompilerServices;

namespace Task02.ViewModels;

using Models;
using ReactiveUI;

public class MainViewModel : ViewModelBase
{
    private readonly Lantern _lantern;
    private readonly Chandelier _chandelier;
    private readonly DeskLamp _deskLamp;
    private readonly FloorLamp _floorLamp;

    public LightingFixture Lantern
    {
        get => _lantern;
        private init
        {
            var lightingFixture = Unsafe.As<LightingFixture>(_lantern);
            this.RaiseAndSetIfChanged<MainViewModel, LightingFixture>(ref lightingFixture, value);
        }
    }

    public LightingFixture Chandelier
    {
        get => _chandelier;
        private init
        {
            var lightingFixture = Unsafe.As<LightingFixture>(_chandelier);
            this.RaiseAndSetIfChanged<MainViewModel, LightingFixture>(ref lightingFixture, value);
        }
    }

    public LightingFixture DeskLamp
    {
        get => _deskLamp;
        private init
        {
            var lightingFixture = Unsafe.As<LightingFixture>(_deskLamp);
            this.RaiseAndSetIfChanged<MainViewModel, LightingFixture>(ref lightingFixture, value);
        }
    }

    public LightingFixture FloorLamp
    {
        get => _floorLamp;
        private init
        {
            var lightingFixture = Unsafe.As<LightingFixture>(_floorLamp);
            this.RaiseAndSetIfChanged<MainViewModel, LightingFixture>(ref lightingFixture, value);
        }
    }

    public bool LanternIsOn => _lantern.IsOn;
    public bool LanternBroken => _lantern.IsSelfBroken;
    public bool ChandelierIsOn => _chandelier.IsOn;
    public bool ChandelierBroken => _chandelier.IsSelfBroken;
    public string ChandelierMode => _chandelier.Mode.GetDescription();
    public bool DeskLampIsOn => _deskLamp.IsOn;
    public bool DeskLampBroken => _deskLamp.IsSelfBroken;
    public bool DeskLampPluggedIn => _deskLamp.IsPluggedIn;
    public bool FloorLampIsOn => _floorLamp.IsOn;
    public bool FloorLampBroken => _floorLamp.IsSelfBroken;
    public bool FloorLampPluggedIn => _floorLamp.IsPluggedIn;

    public MainViewModel()
    {
        _lantern = new Lantern();
        Lantern.StateChanged += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(LanternIsOn));
            this.RaisePropertyChanged(nameof(LanternBroken));
        };
        Lantern.Broken += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(LanternIsOn));
            this.RaisePropertyChanged(nameof(LanternBroken));
        };

        _chandelier = new Chandelier();
        Chandelier.StateChanged += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(ChandelierIsOn));
            this.RaisePropertyChanged(nameof(ChandelierMode));
            this.RaisePropertyChanged(nameof(ChandelierBroken));
        };
        Chandelier.Broken += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(ChandelierIsOn));
            this.RaisePropertyChanged(nameof(ChandelierMode));
            this.RaisePropertyChanged(nameof(ChandelierBroken));
        };

        _deskLamp = new DeskLamp();
        DeskLamp.StateChanged += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(DeskLampIsOn));
            this.RaisePropertyChanged(nameof(DeskLampPluggedIn));
            this.RaisePropertyChanged(nameof(DeskLampBroken));
        };
        DeskLamp.Broken += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(DeskLampIsOn));
            this.RaisePropertyChanged(nameof(DeskLampPluggedIn));
            this.RaisePropertyChanged(nameof(DeskLampBroken));
        };

        _floorLamp = new FloorLamp();
        FloorLamp.StateChanged += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(FloorLampIsOn));
            this.RaisePropertyChanged(nameof(FloorLampPluggedIn));
            this.RaisePropertyChanged(nameof(FloorLampBroken));
        };
        FloorLamp.Broken += (_, _) =>
        {
            this.RaisePropertyChanged(nameof(FloorLampIsOn));
            this.RaisePropertyChanged(nameof(FloorLampPluggedIn));
            this.RaisePropertyChanged(nameof(FloorLampBroken));
        };
    }

    public void LanternTurnOn() => ((ISwitchable)Lantern).TurnOn();

    public void LanternTurnOff() => ((ISwitchable)Lantern).TurnOff();
    
    public void LanternBreak() => ((IBreakable)Lantern).Break();

    public void ChandelierTurnOn() => ((ISwitchable)Chandelier).TurnOn();

    public void ChandelierTurnOff() => ((ISwitchable)Chandelier).TurnOff();
    
    public void ChandelierBreak() => ((IBreakable)Chandelier).Break();

    public void DeskLampTurnOn() => ((ISwitchable)DeskLamp).TurnOn();

    public void DeskLampTurnOff() => ((ISwitchable)DeskLamp).TurnOff();
    
    public void DeskLampPlugIn() => ((IPluggable)DeskLamp).PlugIn();

    public void DeskLampUnplug() => ((IPluggable)DeskLamp).Unplug();
    
    public void DeskLampBreak() => ((IBreakable)DeskLamp).Break();

    public void FloorLampTurnOn() => ((ISwitchable)FloorLamp).TurnOn();

    public void FloorLampTurnOff() => ((ISwitchable)FloorLamp).TurnOff();

    public void FloorLampPlugIn() => ((IPluggable)FloorLamp).PlugIn();

    public void FloorLampUnplug() => ((IPluggable)FloorLamp).Unplug();
    public void FloorLampBreak() => ((IBreakable)FloorLamp).Break();
}