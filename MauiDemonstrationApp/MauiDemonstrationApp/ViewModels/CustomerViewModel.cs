using MauiDemonstrationApp.Models;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MauiDemonstrationApp.ViewModels
{
    public class CustomerViewModel : BindingObject<Customer>
    {
        private int _id;
        private string _name;
        private string _email;
        private string _avatar;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        [Required]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        [Required]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Avatar
        {
            get { return _avatar; }
            set
            {
                if (_avatar != value)
                {
                    _avatar = value;
                    OnPropertyChanged(nameof(Avatar));
                }
            }
        }

        public CustomerViewModel()
        {
        }

        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            Avatar = customer.Avatar;
        }

        public Customer ToModel() => new Customer(Id, Name, Email, Avatar);
    }
}
