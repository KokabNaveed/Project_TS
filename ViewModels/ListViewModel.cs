using Project.Models;
using Project.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Project.Commands;
using Project.ViewModels;

public class ListViewModel : BaseViewModel
{
    public string Title { get; set; }
    public ObservableCollection<ListItem> Items { get; set; } = new();

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    private readonly EmailUserService _emailService;
    private readonly SoftwareService _softwareService;
    private readonly DomainService _domainService;

    private readonly string _type; // "Email", "Software", "Domain"

    public ListViewModel(string type)
    {
        _type = type;

        _emailService = new EmailUserService();
        _softwareService = new SoftwareService();
        _domainService = new DomainService();

        EditCommand = new RelayCommand(o => EditItem(o));
        DeleteCommand = new RelayCommand(o => DeleteItem(o));

        LoadItems();
    }

    private void LoadItems()
    {
        Items.Clear();

        if (_type == "Email")
        {
            Title = "All Emails";
            foreach (var e in _emailService.GetAll())
            {
                Items.Add(new ListItem
                {
                    Id = e.Id,
                    DisplayName = e.EmailAddress,
                    Extra = $"{e.FirstName} {e.LastName}",
                    DateInfo = DateTime.Now, // optional
                    AmountOrStorage = e.StorageGB.ToString()
                });
            }
        }
        else if (_type == "Software")
        {
            Title = "All Software";
            foreach (var s in _softwareService.GetAll())
            {
                Items.Add(new ListItem
                {
                    Id = s.Id,
                    DisplayName = s.SoftwareName,
                    Extra = s.Category,
                    DateInfo = s.RenewalDate ?? s.SubscribedDate,
                    AmountOrStorage = s.Amount.ToString()
                });
            }
        }
        else if (_type == "Domain")
        {
            Title = "All Domains";
            foreach (var d in _domainService.GetAll())
            {
                Items.Add(new ListItem
                {
                    Id = d.Id,
                    DisplayName = d.DomainName,
                    Extra = d.Registrar,
                    DateInfo = d.RenewalDate,
                    AmountOrStorage = d.Amount.ToString()
                });
            }
        }
    }

    private void EditItem(object param)
    {
        // Navigate to Add/Edit control for the type
    }

    private void DeleteItem(object param)
    {
        if (_type == "Email" && param is EmailUser e)
            _emailService.RemoveUser(e);
        else if (_type == "Software" && param is SoftwareSubscription s)
            _softwareService.RemoveSoftwareSubscription(s);
        else if (_type == "Domain" && param is DomainSubscription d)
            _domainService.RemoveDomain(d);

        LoadItems(); // refresh grid
    }
}

// Helper class to unify columns
public class ListItem
{
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Extra { get; set; }
    public DateTime DateInfo { get; set; }
    public string AmountOrStorage { get; set; }
}
