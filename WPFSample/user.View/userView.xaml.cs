using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSample.User.Common;
using WPFSample.User.ViewModel;
using System.Collections;
using System.Data;
using WPFSample.Model;
using System.Web.Script.Serialization;

namespace WPFSample
{
    /// <summary>
    ///show and hide selected data and load data in dropdown.
    /// </summary>
    public partial class userView : Window
    {

        private userViewModel viewModel;
        /// <summary>
        /// fill dataGrid with viewModel.
        /// </summary>
        public userView()
        {
            InitializeComponent();
            viewModel = new userViewModel();
            this.DataContext = viewModel;
            viewModel._isCheck = false;
            dgUsers.ItemsSource = viewModel.users;
            dgUsers.Columns[3].Visibility = Visibility.Hidden;

        }
        /// <summary>
        /// fill dropdown on the basis of distinct userId from viewModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var id = viewModel.users.Select(i => i.userId).Distinct();
            comboBox.ItemsSource = id.ToList();
            if (viewModel != null)
            {
                viewModel = null;
                GC.Collect();
            }
        }
        /// <summary>
        /// get all the values to be displyed from enum and display in dropdown control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextType_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var textType = Enum.GetValues(typeof(enums.enumType));
            comboBox.ItemsSource = textType;
        }
        private void TextType_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //TODO:Need to add code.
        }
        /// <summary>
        /// on selection of dropdown column description is visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            viewModel = new userViewModel();
            var selectedItems = viewModel.users.Where(i => i.userId == Convert.ToInt16(comboBox.SelectedItem)).ToList();
            dgUsers.ItemsSource = selectedItems;
            dgUsers.Columns[3].Visibility = Visibility.Visible;
        }
        /// <summary>
        /// on click of button,selected item in dropdown-type displays HTML,JSON or plain text data formats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            if (ComboType.SelectedValue == null)
            {
                MessageBox.Show("Please select content type description");
                return;
            }
            copyContents contentType = new copyContents();
            viewModel = new userViewModel();
            var dgSelectedData = dgUsers.ItemsSource.Cast<user>();
            string textFormat = null;
            var selectValue = ComboType.SelectedValue;
            if (selectValue.ToString().ToLower().Equals("json"))
            {
                JavaScriptSerializer serializeData = new JavaScriptSerializer();
                textFormat = serializeData.Serialize(dgSelectedData);
            }
            else if (selectValue.ToString().ToLower().Equals("html"))
            {
                textFormat = formHtmlTags(dgSelectedData, x => x.id, x => x.title, x => x.userId, x => x.body);

            }
            else if (selectValue.ToString().ToLower().Equals("plaintext"))
            {
                textFormat = GetMyPlaintext(dgSelectedData, x => x.id, x => x.title, x => x.userId, x => x.body);
            }
            contentType.CopyContent.Text = textFormat;
            contentType.Show();
        }
        /// <summary>
        /// on selection of button all the coulmns and their corresponing data display on grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailsInfo(object sender, RoutedEventArgs e)
        {
            viewModel = new userViewModel();
            dgUsers.ItemsSource = viewModel.users;
            dgUsers.Columns[3].Visibility = Visibility.Visible;
        }
        /// <summary>
        /// function to change generic list object in plain text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="plainList"></param>
        /// <param name="plainObject"></param>
        /// <returns></returns>
        public static string GetMyPlaintext<T>(IEnumerable<T> plainList, params Func<T, object>[] plainObject)
        {
            StringBuilder plainText = new StringBuilder();
            foreach (var item in plainList)
            {
                foreach (var plainselObject in plainObject)
                {
                    plainText.Append(plainselObject(item));
                }
            }
            return plainText.ToString();
        }
        /// <summary>
        /// function to change generic list object in HTML format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlList"></param>
        /// <param name="htmlObject"></param>
        /// <returns></returns>
        public static string formHtmlTags<T>(IEnumerable<T> htmlList, params Func<T, object>[] htmlObject)
        {
            string strHeader = "<!DOCTYPE html><html><head><title>User Details in HTML Format</title></head><body>";
            StringBuilder stringHtmlData = new StringBuilder();
            stringHtmlData.Append("<TABLE>\n");
            foreach (var selectedItem in htmlList)
            {
                stringHtmlData.Append("<TR>\n");
                foreach (var htmlselObject in htmlObject)
                {
                    stringHtmlData.Append("<TD>");
                    stringHtmlData.Append(htmlselObject(selectedItem));
                    stringHtmlData.Append("</TD>");
                }
                stringHtmlData.Append("</TR>\n");
            }
            stringHtmlData.Append("</TABLE>");

            return strHeader + stringHtmlData + "</body></html>".ToString();
        }
    }
}
