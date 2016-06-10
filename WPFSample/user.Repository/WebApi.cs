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
using WPFSample.User.Common;

namespace WPFSample.Repository
{
    public class WebApi
    {
        public static ObservableCollection<user> model { get; set; }
        /// <summary>
        /// create a new class webApi to extract the data from Rest api's and stored in model object.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<user> getAllUsers()
        {            
            try
            {               
                    string appConn = enums.PROXY_CONN_NAME.ToString();               
                    using (var proxyClient = new WebClient())
                    {
                        if(model==null)
                        {
                            model = new ObservableCollection<user>();
                            var json = proxyClient.DownloadString(appConn);
                            var serializer = new JavaScriptSerializer();
                            model = serializer.Deserialize<ObservableCollection<user>>(json);
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
