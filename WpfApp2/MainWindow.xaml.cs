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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp2.blackSide;
using WpfApp2.whiteSide;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bw_gueue();
        }
        public UIElement[,] ChessMass = new UIElement[8, 8];
        private void bw_gueue()
        {
            if (!queue)
            {
                wS1.IsEnabled = false;
                wS2.IsEnabled = false;
                wK.IsEnabled  = false;
                wL1.IsEnabled = false;
                wL2.IsEnabled = false;
                wF.IsEnabled  = false;
                wZ1.IsEnabled = false;
                wZ2.IsEnabled = false;
                wP1.IsEnabled = false;
                wP2.IsEnabled = false;
                wP3.IsEnabled = false;
                wP4.IsEnabled = false;
                wP5.IsEnabled = false;
                wP6.IsEnabled = false;
                wP7.IsEnabled = false;
                wP8.IsEnabled = false;
                bS1.IsEnabled = true;
                bS2.IsEnabled = true;
                bK.IsEnabled =  true;
                bL1.IsEnabled = true;
                bL2.IsEnabled = true;
                bF.IsEnabled =  true;
                bZ1.IsEnabled = true;
                bZ2.IsEnabled = true;
                bP1.IsEnabled = true;
                bP2.IsEnabled = true;
                bP3.IsEnabled = true;
                bP4.IsEnabled = true;
                bP5.IsEnabled = true;
                bP6.IsEnabled = true;
                bP7.IsEnabled = true;
                bP8.IsEnabled = true;
            }
            if (queue)
            {
                bS1.IsEnabled = false;
                bS2.IsEnabled = false;
                bK.IsEnabled  = false;
                bL1.IsEnabled = false;
                bL2.IsEnabled = false;
                bF.IsEnabled  = false;
                bZ1.IsEnabled = false;
                bZ2.IsEnabled = false;
                bP1.IsEnabled = false;
                bP2.IsEnabled = false;
                bP3.IsEnabled = false;
                bP4.IsEnabled = false;
                bP5.IsEnabled = false;
                bP6.IsEnabled = false;
                bP7.IsEnabled = false;
                bP8.IsEnabled = false;
                wS1.IsEnabled = true;
                wS2.IsEnabled = true;
                wK.IsEnabled =  true;
                wL1.IsEnabled = true;
                wL2.IsEnabled = true;
                wF.IsEnabled =  true;
                wZ1.IsEnabled = true;
                wZ2.IsEnabled = true;
                wP1.IsEnabled = true;
                wP2.IsEnabled = true;
                wP3.IsEnabled = true;
                wP4.IsEnabled = true;
                wP5.IsEnabled = true;
                wP6.IsEnabled = true;
                wP7.IsEnabled = true;
                wP8.IsEnabled = true;
            }
        }
        public int _X1=0, _Y1=0;
        public  List<int> x = new List<int>();
        public  List<int> y = new List<int>();
        public Image image = new Image();
        public List<Button> btn = new List<Button>();
        //private UIElement[] ChessGradient = new UIElement[64]; 
        private bool queue = true;

        private void wS_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private bool q = false;
        private bool w = false;
        private void clearElementToChess()
        {
            foreach (var item in btn)
            {
                grid_Chess.Children.Remove(item);
            }

            x.Clear();
            y.Clear();
            btn.Clear();
            q = false;
            w = false;
        }
        private void wK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();
            image = (Image)sender;
            whiteK whiteK = new whiteK();
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            foreach (UIElement uIElement in grid_Chess.Children)
            {
                whiteK.Run(uIElement, _X, _Y);
                whiteK.RunKill(uIElement, _X, _Y);
            }
            whiteK.XY(ref x, ref y);
            ButtonGenerator();
        }
        private void wF_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();
            image = (Image)sender;
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            CorrectToEatAndStep(_X, _Y);
            CorrectToEatAndStep1(_X, _Y);
            CorrectToEatAndStep2(_X, _Y);
            CorrectToEatAndStep3(_X, _Y);
            CorrectToEatAndStepS(_X, _Y);
            CorrectToEatAndStepS1(_X, _Y);
            CorrectToEatAndStepS2(_X, _Y);
            CorrectToEatAndStepS3(_X, _Y);

            ButtonGenerator();
        }
        private void bS_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();
            image = (Image)sender;
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            CorrectToEatAndStepS(_X, _Y);
            CorrectToEatAndStepS1(_X, _Y);
            CorrectToEatAndStepS2(_X, _Y);
            CorrectToEatAndStepS3(_X, _Y);

            ButtonGenerator();
        }
        private void bK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();

            image = (Image)sender;
            blackK blackK = new blackK();
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            foreach (UIElement uIElement in grid_Chess.Children)
            {
                blackK.Run(uIElement, _X, _Y);
                blackK.RunKill(uIElement, _X, _Y);


            }
            blackK.XY(ref x, ref y);
            ButtonGenerator();

        }
        private void bP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();
            image = (Image)sender;
            blackP blackP = new blackP();
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            for (int i = 0; i <64; i++)
            {
                blackP.RunLeft(grid_Chess.Children[i], _X, _Y);
                blackP.RunRight(grid_Chess.Children[i], _X, _Y);
                if (blackP.Run1(grid_Chess.Children[i], _X, _Y))
                {
                    w = true;
                }
                if (_Y == 1)
                {
                    q = true;
                }
                if (q & w)
                {
                    blackP.Run2(grid_Chess.Children[i], _X, _Y);
                }
            }
            blackP.XY(ref x, ref y);
            ButtonGenerator();

        }
        private void wP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();

            image = (Image)sender;
            whiteP whiteP = new whiteP();
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            
            if (_Y == 6)
            {
                q = true;
            }
            for (int i = 63; i > 0; i--)
            {
                if (whiteP.Run1(grid_Chess.Children[i], _X, _Y))
                {
                    w = true;
                }
                whiteP.RunLeft(grid_Chess.Children[i], _X, _Y);
                whiteP.RunRight(grid_Chess.Children[i], _X, _Y);
            }     
            for (int i = 63; i > 0; i--)
            {
                if (q == true)
                {
                    if (w == true)
                    {
                        whiteP.Run2(grid_Chess.Children[i], _X, _Y);
                    }
                }
            }
            whiteP.XY(ref x, ref y);
            ButtonGenerator();
        }

        public bool CorrectToEatAndStep(int _X, int _Y)
        {
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {

                    for (int w = _Y + 1; w < 8; w++)
                    {
                        if (i == _Y+w && j == _X)
                        {
                            if (ChessMass[i, j].GetType() == typeof(Label))
                            {
                                x.Add(j);
                                y.Add(i);
                            }
                            if (ChessMass[i, j].GetType() == typeof(Image))
                            {
                                if (ChessMass[i, j].IsEnabled == false)
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }
        public bool CorrectToEatAndStep1(int _X, int _Y)
        {
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {

                    for (int w = _Y + 1; w < 8; w++)
                    {
                        if (i == _Y  && j == _X +w)
                        {
                            if (ChessMass[i, j].GetType() == typeof(Label))
                            {
                                x.Add(j);
                                y.Add(i);
                            }
                            if (ChessMass[i, j].GetType() == typeof(Image))
                            {
                                if (ChessMass[i, j].IsEnabled == false)
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }  
        public bool CorrectToEatAndStep2(int _X, int _Y)
        {
            for (int i = 8; i >= 0; --i)
            {

                for (int j = 8; j >= 0; --j)
                {

                    for (int w = _Y-1; w > 0; w--)
                    {
                        if (i == _Y-w && j == _X)
                        {
                            if (ChessMass[i, j].GetType() == typeof(Label))
                            {
                                x.Add(j);
                                y.Add(i);
                            }
                            if (ChessMass[i, j].GetType() == typeof(Image))
                            {
                                if (ChessMass[i, j].IsEnabled == false)
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }   
        public bool CorrectToEatAndStep3(int _X, int _Y)
        {

            for (int i = 8; i >= 0; --i)
            {

                for (int j = 8; j >= 0; --j)
                {

                    for (int w = _Y - 1; w > 0; w--)
                    {
                        if (i == _Y && j == _X - w)
                        {
                            if (ChessMass[i, j].GetType() == typeof(Label))
                            {
                                x.Add(j);
                                y.Add(i);
                            }
                            if (ChessMass[i, j].GetType() == typeof(Image))
                            {
                                if (ChessMass[i, j].IsEnabled == false)
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }   
        public bool CorrectToEatAndStepS(int _X, int _Y)
        {
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {

                    for (int w = _Y + 1; w < 8; w++)
                    {
                        if (i == _Y+w && j == _X+w)
                        {
                            if (ChessMass[i, j].GetType() == typeof(Label))
                            {
                                x.Add(j);
                                y.Add(i);
                            }
                            if (ChessMass[i, j].GetType() == typeof(Image))
                            {
                                if (ChessMass[i, j].IsEnabled == false)
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }
        public bool CorrectToEatAndStepS1(int _X, int _Y)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 8; j >= 0; --j)
                {
                    for (int w = _Y ; w < 8; w++)
                    {
                        for (int d = _Y - 1; d > 0; d--)
                        {
                            if (i == _Y + w && j == _X - d)
                            {
                                if (ChessMass[i, j].GetType() == typeof(Label))
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                if (ChessMass[i, j].GetType() == typeof(Image))
                                {
                                    if (ChessMass[i, j].IsEnabled == false)
                                    {
                                        x.Add(j);
                                        y.Add(i);
                                    }
                                    return false;
                                }
                            }
                        }
                    }
                            
                }
            }
            return true;
        }  

        public bool CorrectToEatAndStepS2(int _X, int _Y)
        {
            for (int i = 8; i >= 0; --i)
            {

                for (int j = 8; j >= 0; --j)
                {

                    for (int w = _Y - 1; w > 0; w--)
                    {
                        if (i == _Y-w && j == _X-w)
                        {
                            if (ChessMass[i, j].GetType() == typeof(Label))
                            {
                                x.Add(j);
                                y.Add(i);
                            }
                            if (ChessMass[i, j].GetType() == typeof(Image))
                            {
                                if (ChessMass[i, j].IsEnabled == false)
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }   
        public bool CorrectToEatAndStepS3(int _X, int _Y)
        {
            for (int i = 8; i >= 0; --i)
            {

                for (int j = 0; j < 8; j++)
                {

                    for (int w = _Y - 1; w > 0; w--)
                    {
                        for (int q = _Y + 1; q <8; q++)
                        {
                            if (i == _Y - w && j == _X + q)
                            {
                                if (ChessMass[i, j].GetType() == typeof(Label))
                                {
                                    x.Add(j);
                                    y.Add(i);
                                }
                                if (ChessMass[i, j].GetType() == typeof(Image))
                                {
                                    if (ChessMass[i, j].IsEnabled == false)
                                    {
                                        x.Add(j);
                                        y.Add(i);
                                    }
                                    return false;
                                }
                            }
                        }
                    }

                }
            }
            return true;
        }

        private void bwZ_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();
            image = (Image)sender;
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            CorrectToEatAndStep(_X,_Y);
            CorrectToEatAndStep1(_X, _Y);
            CorrectToEatAndStep2(_X, _Y);
            CorrectToEatAndStep3(_X, _Y);

            ButtonGenerator();
        }
        private void bwL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clearElementToChess();

            image = (Image)sender;
            bwL bwL = new bwL();
            int _X = Grid.GetColumn((Image)sender);
            int _Y = Grid.GetRow((Image)sender);
            foreach (UIElement uIElement in grid_Chess.Children)
            {
                bwL.Run(uIElement, _X, _Y);
                bwL.RunKill(uIElement, _X, _Y);
            }
            bwL.XY(ref x, ref y);
            ButtonGenerator();

        }

        private void ButtonGenerator()
        {
            for (int i = 0; i < x.Count; i++)
            {
                Button button = new Button();
                button.Width = 30;
                button.Height = 30;
                button.Background = new SolidColorBrush(Colors.Green);
                button.Click += Button_Click;
                Grid.SetColumn(button, x[i]);
                Grid.SetRow(button, y[i]);
                Canvas.SetZIndex(button, Canvas.GetZIndex(button) + 1);
                btn.Add(button);
                grid_Chess.Children.Add(button);
            }
        }
        private void LabelGenerator(int i,int j)
        {
            Label label = new Label();
            Grid.SetColumn(label, j);
            Grid.SetRow(label, i);
            Canvas.SetZIndex(label, Canvas.GetZIndex(label) - 1);
            grid_Chess.Children.Add(label);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i > 1 && i < 6)
                    {
                        LabelGenerator(i,j);
                    }
                }
            }
            foreach (UIElement uIElmnt in grid_Chess.Children)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Grid.GetColumn(uIElmnt) == j & Grid.GetRow(uIElmnt) == i)
                        {
                            ChessMass[i, j] = uIElmnt;
                        }
                    }
                }
            }
            this.Play.IsEnabled = false;
        }
        private UIElement element = new UIElement();
        private int CheckImgOrLbl()
        {
            for (int i = 63; i > 0; i--)
            {
                if (Grid.GetColumn(grid_Chess.Children[i]) == _X1 && Grid.GetRow(grid_Chess.Children[i]) == _Y1)
                {
                    if (grid_Chess.Children[i].GetType() == typeof(Image))
                    {
                        element = grid_Chess.Children[i];
                        return 1;
                    }
                }
            }
            return 0;
        }

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    foreach (UIElement uIElement in grid_Chess.Children)
        //    {
        //        this.text.Items.Add(Grid.GetColumn(uIElement).ToString() + " " + Grid.GetRow(uIElement) + uIElement.GetType());

        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearElementToChess();
            _Y1 = Grid.GetRow((Button)sender);
            _X1 = Grid.GetColumn((Button)sender);
                Label label = new Label();
                Grid.SetColumn(label, Grid.GetColumn(image));
                Grid.SetRow(label, Grid.GetRow(image));
                Canvas.SetZIndex(label, Canvas.GetZIndex(label) - 1);
            if (CheckImgOrLbl() == 1)
            {
                grid_Chess.Children.Add(label);
                if (element == bK)
                {
                    MessageBoxResult result = MessageBox.Show("White win !!!");
                    if (result == MessageBoxResult.OK)
                    {
                        Application.Current.Shutdown();
                    }
                }
                if (element == wK)
                { 
                    MessageBoxResult result = MessageBox.Show("Black win !!!");
                    if (result == MessageBoxResult.OK)
                    {
                        Application.Current.Shutdown();
                    }
                }
                Grid.SetRow(image, _Y1);
                Grid.SetColumn(image, _X1);
                grid_Chess.Children.Remove(element);
            }
            if (CheckImgOrLbl() == 0)
            {
                for (int i = 0; i < 64; i++) 
                {
                    if (Grid.GetRow(grid_Chess.Children[i]) == _Y1 && Grid.GetColumn(grid_Chess.Children[i]) == _X1)
                    {
                        if (grid_Chess.Children[i].GetType() == typeof(Label))
                        {
                            Grid.SetRow(grid_Chess.Children[i], Grid.GetRow(image));
                            Grid.SetColumn(grid_Chess.Children[i], Grid.GetColumn(image));
                            Grid.SetRow(image, _Y1);
                            Grid.SetColumn(image, _X1);
                        }
                    }
                }
            }
            foreach (UIElement uIElmnt in grid_Chess.Children)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Grid.GetColumn(uIElmnt) == j & Grid.GetRow(uIElmnt) == i)
                        {
                            ChessMass[i, j] = uIElmnt;
                        }
                    }
                }
            }
            while (true)
            {
                if (queue) { queue = false; bw_gueue(); break; };
                if (!queue) { queue = true; bw_gueue(); break; };
            }
            //if (grid_Chess.Children.Count >= 64) { MessageBox.Show(grid_Chess.Children.Count.ToString()); }

        }


    }
}
