using System;
using System.Collections.Generic;

namespace WPFSample.Model
{
    /// <summary>
    /// Create model object to store rest api's object. 
    /// </summary>
    public class user
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
