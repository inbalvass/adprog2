using System;
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
    /// Interaction logic for MPwindow.xaml
    /// </summary>
    public partial class MPwindow : Window
    {
        private Client myClient;
        private MPViewModel vm;
        private string name;
        private MazeBoard mazeBoard;
    //    private MazeBoard mazeBoardPlay;

        public MPwindow(string name, Client client, string json)
        {
            InitializeComponent();
            this.myClient = client;
            vm = new MPViewModel(client);
            this.DataContext = vm;

            this.SizeChanged += OnWindowSizeChanged;

            this.name = name;
            vm.VM_mazeStr = json;

            this.mazeBoard = new MazeBoard();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("VM_mazeStr");
            binding.Source = vm;
            BindingOperations.SetBinding(mazeBoard, MazeBoard.mazeStrProperty, binding);




        }

        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void clicked_restart(object sender, RoutedEventArgs e)
        {
            AreYouSureRestart sure = new AreYouSureRestart();
            sure.ShowDialog();
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Title = name;
            MazeBoard mazeBoardPlay = new MazeBoard();
            mazeBoardPlay.mazeStr = this.mazeBoard.mazeStr;
            this.canvas1.Children.Add(this.mazeBoard);
            this.canvas2.Children.Add(mazeBoardPlay);


        }

        /// <summary>
        /// return to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clicked_menu(object sender, RoutedEventArgs e)
        {
          //  AreYouSureMenu sure = new AreYouSureMenu(this);
            //sure.ShowDialog();
        }
    }
}
