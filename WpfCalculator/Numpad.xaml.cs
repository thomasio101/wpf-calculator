using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for Numpad.xaml
    /// </summary>
    public partial class Numpad : UserControl
    {
        private static readonly string[,] numpadLayout = new string[,]
        {
            {
                "1", "2", "3", "+", "CLR"
            },
            {
                "4", "5", "6", "-", "€"
            },
            {
                "7", "8", "9", "*", "%"
            },
            {
                "(-)", "0", ",", "/", "GO"
            }
        };

        public Numpad()
        {
            InitializeComponent();

            void AddButton(int row, int column, string text)
            {
                var button = new Button()
                {
                    Content = text
                };

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);

                ButtonGrid.Children.Add(button);
            }

            int rowCount = numpadLayout.GetLength(0), columnCount = numpadLayout.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                ButtonGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                });

                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (rowIndex == 0)
                        ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition()
                        {
                            Width = new GridLength(1, GridUnitType.Star)
                        });

                    AddButton(rowIndex, columnIndex, numpadLayout[rowIndex, columnIndex]);
                }
            }
        }
    }
}
