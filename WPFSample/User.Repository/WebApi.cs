using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using WPFSample.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;

namespace WPFSample.Repository
{
    public class WebApi
    {
        public static ObservableCollection<Users> model = null;
        /// <summary>
        /// create a new class webApi to extract the data from Rest api's and stored in model object.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Users> GetAllUsers()
        {
            
            try
            {
                    string appConn = ConfigurationManager.AppSettings["proxyConnName"].ToString();
                    using (var proxyclient = new WebClient())
                    {
                        if(model==null)
                        {
                            var json = proxyclient.DownloadString(appConn);
                            var serializer = new JavaScriptSerializer();
                            model = serializer.Deserialize<ObservableCollection<Users>>(json);
                        }
                                                   
                    }

                }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
                //Log exceptions in source file.
                throw (ex);
            }           
            return model;

        }
    }
}
