using System;
using System.Collections.ObjectModel;
using Project.Models;
using Project.Services;
using Project.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly HomeService _service = new();

    public int TotalEmails { get; set; }
    public int TotalSoftware { get; set; }
    public int TotalDomain { get; set; }

    public ObservableCollection<string> ExpiringTypes { get; } = new() { "Software", "Domain" };
    public ObservableCollection<string> ExpiringPeriods { get; } = new() { "Month", "Year" };

    public ObservableCollection<ExpiringItem> FilteredExpiringSubscriptions { get; set; } = new();

    private string _selectedExpiringType;
    public string SelectedExpiringType
    {
        get => _selectedExpiringType;
        set
        {
            _selectedExpiringType = value;
            OnPropertyChanged();
            LoadExpiring();
        }
    }

    private string _selectedExpiringPeriod;
    public string SelectedExpiringPeriod
    {
        get => _selectedExpiringPeriod;
        set
        {
            _selectedExpiringPeriod = value;
            OnPropertyChanged();
            LoadExpiring();
        }
    }

    public HomeViewModel()
    {
        TotalEmails = _service.GetTotalEmails();
        TotalSoftware = _service.GetTotalSoftware();
        TotalDomain = _service.GetTotalDomains();

        SelectedExpiringType = "Software";
        SelectedExpiringPeriod = "Month";
    }

    private void LoadExpiring()
    {
        DateTime limit = SelectedExpiringPeriod == "Month" ? DateTime.Today.AddMonths(1) : DateTime.Today.AddYears(1);
        FilteredExpiringSubscriptions.Clear();

        var list = SelectedExpiringType == "Software"
            ? _service.GetExpiringSoftware(limit)
            : _service.GetExpiringDomains(limit);

        foreach (var item in list)
            FilteredExpiringSubscriptions.Add(item);
    }
}
