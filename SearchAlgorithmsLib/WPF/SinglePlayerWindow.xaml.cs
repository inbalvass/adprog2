﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window

    {
        private SPWindowViewModel vm;
        private string name;
        private int rows, cols;
        private MazeBoard mazeBoard;

        public SinglePlayerWindow(string name, int row, int col)
        {
            
            InitializeComponent();
            vm = new SPWindowViewModel();
            this.DataContext = vm;

            

            this.name = name;
            this.rows = row;
            this.cols = col;
            vm.generate(name, rows, cols);

   
            this.mazeBoard = new MazeBoard();

            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);

        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
             //the title need to be bounded to the name that entered- אני לא בטוחה שכך אכן נראה data binding
            //mazeBoarder.Rows = rows;
            //mazeBoarder.Cols = cols;
            
           // stackPanel1.Children.Add(this.mazeBoard);


        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            AreYouSureRestart sure = new AreYouSureRestart();
            sure.ShowDialog();
        }

        private void clicked_solve(object sender, RoutedEventArgs e)
        {
            //*****maybe in different thread? ****
            string solution= vm.solve(name);
            //********
                        //צריך להעביר את השחקן להתחלה ואז פשוט להזיז אותו צעד צעד לפתרון.

        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Title = name;

            canvas.Children.Add(this.mazeBoard);
            
        }

        /// <summary>
        /// return to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clicked_menu(object sender, RoutedEventArgs e)
        {
            AreYouSureMenu sure = new AreYouSureMenu(this);
            sure.ShowDialog();
        }
    }
}
