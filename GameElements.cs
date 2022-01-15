using System.ComponentModel;

namespace Chess;

public class GameElements : INotifyPropertyChanged {
  public event PropertyChangedEventHandler? PropertyChanged;
  private bool CheckPropertyChanged<T>(string propertyName, ref T oldValue, ref T newValue) {
    if (oldValue is null && newValue is null) return false;

    if (oldValue is null && newValue is not null || !oldValue!.Equals(newValue)) {
      oldValue = newValue;
      FirePropertyChanged(propertyName);
      return true;
    }

    return false;
  }

  private void FirePropertyChanged(string propertyName) {
    if (PropertyChanged is null) return;
    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
  }

  private string _gameText = "White to move";
  public string GameText { 
    get => _gameText; 
    set {
      if (CheckPropertyChanged(nameof(GameText), ref _gameText, ref value)) FirePropertyChanged(nameof(GameText));
    }
  }

  private string _blackTimer = "5:00";
  public string BlackTimer {
    get => _blackTimer;
    set {
      if (CheckPropertyChanged(nameof(BlackTimer), ref _blackTimer, ref value)) FirePropertyChanged(nameof(BlackTimer));
    }
  }

  private string _whiteTimer = "5:00";
  public string WhiteTimer {
    get => _whiteTimer;
    set {
      if (CheckPropertyChanged(nameof(WhiteTimer), ref _whiteTimer, ref value)) FirePropertyChanged(nameof(WhiteTimer));
    }
  }

  private bool _gameIsOver = false;
  public bool GameIsOver {
    get => _gameIsOver;
    set {
      if (CheckPropertyChanged(nameof(GameIsOver), ref _gameIsOver, ref value)) FirePropertyChanged(nameof(GameIsOver));
    }
  }
}
