using System;
using System.Collections.Generic;

namespace WPFSample.Model
{
    /// <summary>
    /// Create model object to store rest api's object. 
    /// </summary>
    public class Users
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string title { get; set; }
        public string body { get; set; }          
    }
}
