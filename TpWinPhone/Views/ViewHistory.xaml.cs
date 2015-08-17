using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TpWinPhone.Entities;
using TpWinPhone.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d’élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556

namespace TpWinPhone.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ViewHistory : PivotItem
    {
        public ViewHistory()
		{
			InitializeComponent();
		}

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReadContactList_Loaded();
        }
        public void ReadContactList_Loaded()
        {
            DatabaseHelperClass dbHelper = new DatabaseHelperClass();
            List<Record> listRecords =  dbHelper.getAllRecords();//Get all DB contacts
                listBoxobj.ItemsSource = listRecords.OrderByDescending(i => i.id).ToList();//Binding DB data.  
            
        }

        private void btn_deleteAll_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass dbHelper = new DatabaseHelperClass();
            dbHelper.DeleteAllRecords();
            ReadContactList_Loaded();
        } 
    }
    
}
