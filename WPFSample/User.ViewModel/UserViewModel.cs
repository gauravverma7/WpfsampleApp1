using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using WPFSample.Model;
using WPFSample.Repository;

namespace WPFSample.User.ViewModel
{
    /// <summary>
    /// gererate properties for different objects and event handlers.
    /// </summary>
    public class UserViewModel
    {
        private Users _users=new Users();
        public Boolean _isCheck;
        public List<Users> userDetails;
        //get set UserID property
        public int UserId
        {
            get { return _users.Id; }
            set
            {
                _users.Id = value;
                OnPropertyChanged("UserId");
            }
        }      
        public int Id
        {
            get { return _users.Id; }
            set
            {
                _users.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string title
        {
            get { return _users.title; }
            set
            {
                _users.title = value;
                OnPropertyChanged("title");
            }
        }
        public string body
        {
            get { return _users.body; }
            set
            {
                _users.body = value;
                OnPropertyChanged("body");
            }
        }

        public ObservableCollection<Users> users { get 
        {
            if (userDetails == null)
            {
                return allUsers();
            }
            else
            {
                return new ObservableCollection<Users>(userDetails);
            }
              
        } }
        public event PropertyChangedEventHandler PropertyChanged;
       
        public void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Users> allUsers()
        {
            WebApi usersdata = new WebApi();
            userDetails = usersdata.GetAllUsers().OrderBy(i => i.Id).ThenBy(j => j.title).ToList();
            return new ObservableCollection<Users>(userDetails);
        }
        public ObservableCollection<int> comboUserID()
        {
            WebApi usersdata = new WebApi();
            var userID = users.Select(i => i.userId);
            return new ObservableCollection<int>(userID);
        }

    }
}
