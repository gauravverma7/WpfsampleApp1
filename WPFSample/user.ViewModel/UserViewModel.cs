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
    public class userViewModel
    {
        private user _users = new user();
        public Boolean _isCheck;
        public List<user> userDetails;
        //get set UserID property
        public int UserId
        {
            get { return _users.id; }
            set
            {
                _users.id = value;
                OnPropertyChanged("UserId");
            }
        }
        //get set iD property
        public int Id
        {
            get { return _users.id; }
            set
            {
                _users.id = value;
                OnPropertyChanged("id");
            }
        }
        //get set title property
        public string title
        {
            get { return _users.title; }
            set
            {
                _users.title = value;
                OnPropertyChanged("title");
            }
        }
        //get set body property
        public string body
        {
            get { return _users.body; }
            set
            {
                _users.body = value;
                OnPropertyChanged("body");
            }
        }
        //create collection object for all users data.
        public ObservableCollection<user> users
        {
            get 
        {
            if (userDetails == null)
            {
                return allUsers();
            }
            else
            {
                return new ObservableCollection<user>(userDetails);
            }
              
        } }

        public event PropertyChangedEventHandler PropertyChanged;
       /// <summary>
       /// check even any changes in property.
       /// </summary>
       /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// collection to get all data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<user> allUsers()
        {
            WebApi usersdata = new WebApi();
            userDetails = usersdata.getAllUsers().OrderBy(i => i.id).ThenBy(j => j.title).ToList();
            return new ObservableCollection<user>(userDetails);
        }
        /// <summary>
        /// get selected data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<int> comboUserID()
        {
            WebApi usersdata = new WebApi();
            var userID = users.Select(i => i.userId);
            return new ObservableCollection<int>(userID);
        }

    }
}
