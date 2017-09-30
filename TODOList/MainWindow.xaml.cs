using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TODOList.Models;

namespace TODOList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int id = 0;
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public MainWindow()
        {
            InitializeComponent();

            dpExecutionDate.SelectedDate = DateTime.Now;
            dpDate.SelectedDate = DateTime.Now;

            Refresh();
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private string Validate()
        {
            string errorContent = "";
            if (string.IsNullOrEmpty(txtTitle.Text)) errorContent += "Title field is required.\n";
            if (string.IsNullOrEmpty(dpExecutionDate.Text)) errorContent += "Date field is required.\n";

            return errorContent;
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            string validateError = Validate();
            if(validateError != "")
            {
                MessageBox.Show("Error while saving task:\n" + validateError,"Validate error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CustomTask task = new CustomTask();

            if (id > 0)
            {
                task = new CustomTasks().GetTask(id);
            }

            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            task.ExecutionDate = dpExecutionDate.SelectedDate.Value.Date;
            task.CreationDate = DateTime.Now;

            task.SaveOrUpdate();
            Refresh();
            CleanForm();
            if (btnCancel.Visibility == Visibility.Visible) btnCancel.Visibility = Visibility.Hidden;
        }

        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                CustomTasks ts = new CustomTasks();
                CustomTask task = button.DataContext as CustomTask;
                if (task != null) ts.Remove(task.Id);
                Refresh();
            }
        }

        public void Refresh()
        {
            Dictionary<string,object> filters = new Dictionary<string,object>();

            if (dpDate.SelectedDate.HasValue)
            {
                filters["Date"] = dpDate.SelectedDate;
            }

            lvTasks.ItemsSource = new CustomTasks().GetTasks(filters);
        }

        private void lvTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomTask task = lvTasks.SelectedItem as CustomTask;
            if (task != null)
            {
                FillForm(task);
                id = task.Id;
                btnAddTask.Content = "Save changes";
                btnCancel.Visibility = Visibility.Visible;
            }
        }

        private void CleanForm()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            dpExecutionDate.SelectedDate = DateTime.Now;
            id = 0;
            btnAddTask.Content = "Create task";
        }

        private void FillForm(CustomTask task)
        {
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dpExecutionDate.SelectedDate = task.ExecutionDate;
        }

        private void lvTasks_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    if (header != "") Sort(header, direction);

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(lvTasks.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CleanForm();
            Refresh();
            btnCancel.Visibility = Visibility.Hidden;
        }
    }

}
